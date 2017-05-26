using System.Linq;

namespace GringottsDb
{
    using Models;
    using System;

    public class FirstLetter
    {
        private static readonly GringottsDbContext Gringotts = new GringottsDbContext();

        public static void Main()
        {
            //19.
            //FIRST WAY:
            //100TIMES SLOWER !
            Console.WriteLine(string.Join("\n", Gringotts.WizzardDeposits
               .Where(wiz => wiz.DepositGroup.Equals("Troll Chest"))
               .Select(w => w.FirstName.Substring(0, 1))
               .Distinct()
               .OrderBy(x => x)));

            //SECOND WAY
            //100 TIMES FASTER
            //            var wizzards = Gringotts.WizzardDeposits.Where(wiz => wiz.DepositGroup.Equals("Troll Chest"));
            //
            //            List<char> firstLetterWizzards = new List<char>();
            //
            //            foreach (var wizzard in wizzards)
            //            {
            //                firstLetterWizzards.Add(wizzard.FirstName[0]);
            //            }
            //
            //            var result = firstLetterWizzards
            //                .Distinct()
            //                .OrderBy(x => x);
            //
            //            foreach (var letters in result)
            //            {
            //                Console.WriteLine(letters);
            //            }

            Console.ReadKey();
        }
    }
}