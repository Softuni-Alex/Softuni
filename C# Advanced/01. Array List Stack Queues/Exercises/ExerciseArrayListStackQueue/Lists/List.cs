namespace Lists
{
    public class List
    {
        public static void Main()
        {
            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //  for (int i = 0; i < numbers.Count; i++)
            //  {
            //      Console.Write(numbers[i] + " ");
            //  }

            // foreach (var number in numbers)
            // {
            //     Console.WriteLine(number);
            // }

            //here you can resize  and check the current capacity of the list
            //  Console.WriteLine("The capacity of the list is: " + numbers.Capacity);



            //ADDRANGE

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //List<int> num = new List<int>();
            //num.Add(31);

            //numbers.AddRange(num);
            //foreach (var element in numbers)
            //{
            //    Console.WriteLine(element);
            //}


            //CLEAR whole list makes count 0 but capacity is the same

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);
            //numbers.Clear();
            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}


            // we give an element from our list like a parameter in indexof method and it returns the index

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //Console.WriteLine(numbers.IndexOf(2));



            //INSERT the given element at wanted position(index)

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //numbers.Insert(0, 5);

            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}


            //INSERTRANGE inserts collection(many items) at desired index

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);
            //List<int> num = new List<int>();
            //num.Add(2);

            //numbers.InsertRange(3, num);

            //foreach (var n in numbers)
            //{
            //    Console.WriteLine(n);
            //}



            //REMOVE the desired item from the list

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //numbers.Remove(2);

            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}


            //REMOVEAT the element on given index (position)

            //    List<int> numbers = new List<int>();
            //    numbers.Add(3);
            //    numbers.Add(2);
            //    numbers.Add(2124);

            //    numbers.RemoveAt(0);



            //reverses the given collection(list)

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //numbers.Reverse();

            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}



            //SORT the numbers ascending

            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(4);

            //numbers.Sort();

            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}


            //convert a list into array
            //List<int> numbers = new List<int>();
            //numbers.Add(3);
            //numbers.Add(2);
            //numbers.Add(2124);

            //numbers.ToArray();
        }
    }
}