using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LittleJohn
{
    class LittleJohn
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sb.AppendFormat(" {0}", Console.ReadLine());
            }

            Regex regex = new Regex(@"(>>>----->>)|(>>----->)|(>----->)");

            MatchCollection arrows = regex.Matches(sb.ToString());

            int largeArrowCounter = 0;
            int mediumArrowCounter = 0;
            int smallArrowCounter = 0;

            foreach (Match arrow in arrows)
            {
                if (!string.IsNullOrEmpty(arrow.Groups[1].Value))
                {
                    largeArrowCounter++;
                }
                else if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
                {
                    mediumArrowCounter++;
                }
                else
                {
                    smallArrowCounter++;
                }
            }

            string totalCounter = string.Format("{0}{1}{2}", smallArrowCounter, mediumArrowCounter, largeArrowCounter);

            long binary = long.Parse(totalCounter);

            string binaryNum = Convert.ToString(binary, 2);

            string reversedBinaryNum = new string(binaryNum.Reverse().ToArray());

            string concat = binaryNum + reversedBinaryNum;

            long result = Convert.ToInt64(concat, 2);

            Console.WriteLine(result);
        }
    }
}