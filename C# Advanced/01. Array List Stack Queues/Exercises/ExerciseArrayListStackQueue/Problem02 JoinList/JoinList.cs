namespace Problem02_JoinList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JoinList
    {
        public static void Main()
        {


            string[] firstLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> myList = new List<int>();
            List<int> listForFormatting = new List<int>();

            for (int i = 0; i < firstLine.Length; i++)
            {
                listForFormatting.Add(int.Parse(firstLine[i]));
            }

            for (int j = 0; j < secondLine.Length; j++)
            {
                listForFormatting.Add(int.Parse(secondLine[j]));
            }

            //// Distinct removes all duplicate elements in a collection. 
            //// It returns only the distinct elements. 
            //// The System.Linq namespace provides this extension method.
            myList = listForFormatting.Distinct().ToList();

            foreach (var list in myList)
            {
                Console.Write(list + " ");
            }
        }
    }
}