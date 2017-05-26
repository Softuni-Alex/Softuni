using ExamISIS.HackersGroup;
using ExamISIS.Interfaces;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamISIS.Engine
{
    public class CommandParser : ICommand
    {
        private readonly IWarEffectFactory warEffectFactory;
        private readonly IAttackTypes attackFactory;
        private readonly IData data;
        private StringBuilder totalOutput;
        private readonly IConsoleWriter output;
        private bool GetEventStatus;

        private string pattern = @"(\w*)\.([A-Za-z0-9]+)\((\d*)\,*\s*(\d*)\,*\s*(\w*)\,*\s*(\w*)\)";

        public CommandParser(IWarEffectFactory warEffectFactory,
            IAttackTypes attackFactory,
            IData data,
            StringBuilder totalOutput,
            IConsoleWriter output)
        {
            this.warEffectFactory = warEffectFactory;
            this.attackFactory = attackFactory;
            this.data = data;
            this.totalOutput = totalOutput;
            this.output = output;

        }

        public void UpdateGroups()
        {
            foreach (var group in data.Groups)
            {
                group.Update();
            }
        }

        public void ExecuteCommand(string input)
        {

            Regex rex = new Regex(pattern);
            Match match = rex.Match(input);

            MatchCollection matchesOp = rex.Matches(input);

            foreach (Match m in matchesOp)
            {
                var firstCommanda = m.Groups[2].Value;
                switch (firstCommanda)
                {
                    case "create":
                        CreateCommand(match);
                        break;

                    case "attack":
                        AttackCommand(match);
                        break;

                    case "akbar":
                        break;

                    case "status":
                        StatusCommand();
                        totalOutput.Append(StatusCommand());
                        output.WriteLine(totalOutput.ToString().Trim());

                        this.totalOutput = new StringBuilder();
                        break;

                    case "world().getEvents().status()":
                        GetEventStatus = true;
                        break;

                }
                UpdateGroups();
            }

        }


        private void CreateCommand(Match match)
        {
            //<name>.create(<health>, <damage>, <war effect>, <attack>) 
            //Cenko.create(30, 15, Kamikaze, Paris)
            var name = match.Groups[1].Value;
            var health = int.Parse(match.Groups[3].Value);
            var damage = int.Parse(match.Groups[4].Value);
            var wareffect = match.Groups[5].Value;
            var attack = match.Groups[6].Value;

            var WarEffect = warEffectFactory.CreateWarEffect(wareffect);

            var Attack = attackFactory.CreateWarEffect(attack);

            //string name, int health, int damage, WarEffects warEffect, AttackTypes groupAttackType
            var Group = new HackGroup(name, health, damage, WarEffect, Attack);

            data.AddGroup(Group);
        }

        private void AttackCommand(Match match)
        {
            var att = match.Groups[1].Value;
            var tar = match.Groups[5].Value;

            var attacker = this.data.Groups
                .FirstOrDefault(x => x.Name == att);

            var target = this.data.Groups
                .FirstOrDefault(x => x.Name == tar);

            if (GetEventStatus)
            {
                this.output.WriteLine(string.Format("Group {0} toggled {1}", attacker.Name, attacker.WarEffect.ToString()));

            }

            attacker.Attack(target);
        }

        private string StatusCommand()
        {
            StringBuilder currentBuilder = new StringBuilder();
            var sortedGroups = this.data.Groups
                .OrderByDescending(x => x.Health)
                .ThenBy(x => x.Damage);

            foreach (var group in sortedGroups)
            {
                if (group.Health <= 0)
                {
                    currentBuilder.AppendFormat("Group {0} AMEN", group.Name)
                        .AppendLine();
                }
                else
                {
                    currentBuilder.Append(group.ToString());
                }
            }

            return currentBuilder.ToString();
        }


    }
}
