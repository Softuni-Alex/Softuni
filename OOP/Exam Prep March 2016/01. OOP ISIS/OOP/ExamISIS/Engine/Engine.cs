using ExamISIS.Engine.Factories;
using ExamISIS.Interfaces;
using ExamISIS.UI;
using System.Text;

namespace ExamISIS.Engine
{
    public class Engine
    {
        //initialize
        private static IWarEffectFactory warEffectFactory = new WarEffectFactory();
        private static IAttackTypes attackFactory = new AttackFactory();
        private static IData data = new Data();
        private static StringBuilder totalOutput = new StringBuilder();
        private static IConsoleWriter output = new ConsoleWriter();

        private const string EndCommand = "world.apocalypse()";
        private ICommand commandParser = new CommandParser(warEffectFactory,
            attackFactory,
            data,
            totalOutput,
            output
            );


        public void Run()
        {
            var line = new ConsoleReader();
            var input = line.ReadLine();

            while (input != EndCommand)
            {
                commandParser.ExecuteCommand(input);

                //commandParser.UpdateGroups();

                input = line.ReadLine();
            }
        }
    }
}