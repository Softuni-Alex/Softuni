namespace ExerciseArrayListStackQueue
{
    public class Array
    {
        public static void Main()
        {
            // var myarray = new int[5];
            // myarray[0] = 1;
            // myarray[1] = 5151;

            //Console.WriteLine(string.Join(", ", myarray));



            // int[] numbers = { 3, 4, 5, 6, 7, 7, 8, 9, 0 };
            //
            // for (int i = 0; i < numbers.Length; i++)
            // {
            //     Console.WriteLine("[{0}] = {1}",i,numbers[i]);
            // }



            //  string[] names = {"Alex", "John", "Deni", "Nikol"};
            //
            //  Console.WriteLine(string.Join(", ",names));


            //reverse an array

            //int[] numbers = { 11110, 11, 12, 13, 14, 15, 16, 17, 18, 19, 2234560 };

            //for (int i = numbers.Length - 1; i >= 0; i--)
            //{
            //    Console.Write(numbers[i] + " ");
            //}

            //index of 

            //int[] myarray = new int[5];
            //myarray[0] = 1;
            //myarray[1] = 51;
            //myarray[2] = 1;
            //myarray[3] = 5;
            //myarray[4] = 3;

            //Console.WriteLine(System.Array.IndexOf(myarray,51));


            //reverse with method

            //int[] myarray = new int[5];
            //myarray[0] = 1;
            //myarray[1] = 51;
            //myarray[2] = 1;
            //myarray[3] = 5;
            //myarray[4] = 3;

            //System.Array.Reverse(myarray);

            //foreach (var array in myarray)
            //{
            //    Console.WriteLine(array);
            //}



            //sort an array

            //int[] myarray = new int[5];
            //myarray[0] = 1;
            //myarray[1] = 51;
            //myarray[2] = 1;
            //myarray[3] = 5;
            //myarray[4] = 3;

            //System.Array.Sort(myarray);

            //foreach (var sortedArray in myarray)
            //{
            //    Console.WriteLine(sortedArray);
            //}



            //sums stava nums (debug it)
            string[] nums = { "1", "2", "3", "4", "5" };
            string[] sums = { "2", "4", "6", "8", "10" };

            System.Array.Copy(sums, nums, 5);
        }
    }
}