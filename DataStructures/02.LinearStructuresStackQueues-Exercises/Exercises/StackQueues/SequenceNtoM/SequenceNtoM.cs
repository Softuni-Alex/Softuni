using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceNtoM
{
    class SequenceNtoM
    {
        public SequenceNtoM(int value, SequenceNtoM previousItem)
        {
            this.Value = value;
            this.PreviousItem = previousItem;
        }

        public int Value { get; }

        public SequenceNtoM PreviousItem { get; }
    }

    class Program
    {
        private static int[] ParseToInt(string[] input)
        {
            int[] parsedNums = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                parsedNums[i] = int.Parse(input[i]);
            }

            return parsedNums;
        }

        private static void PrintSolution(SequenceNtoM item)
        {
            Stack<int> output = new Stack<int>();

            while (item != null)
            {
                output.Push(item.Value);
                item = item.PreviousItem;
            }

            Console.WriteLine(string.Join(" -> ", output));
        }

        static void Main(string[] args)
        {
            int[] nums = ParseToInt(Console.ReadLine().Split());

            int n = nums[0];
            int m = nums[1];

            Queue<SequenceNtoM> items = new Queue<SequenceNtoM>();

            items.Enqueue(new SequenceNtoM(n, null));

            while (items.Count > 0)
            {
                SequenceNtoM currentItem = items.Dequeue();

                if (currentItem.Value < m)
                {
                    items.Enqueue(new SequenceNtoM(currentItem.Value + 1, currentItem));
                    items.Enqueue(new SequenceNtoM(currentItem.Value + 2, currentItem));
                    items.Enqueue(new SequenceNtoM(currentItem.Value * 2, currentItem));
                }

                if (currentItem.Value == m)
                {
                    PrintSolution(currentItem);
                    break;
                }
            }
        }
    }
}