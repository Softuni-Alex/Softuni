using System;
using System.Collections.Generic;

namespace DelegatesEventsHomeWork
{
    class Program
    {
        static void Main()
        {

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var filterCollection = nums.WhereNot(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", filterCollection));


            var student = new List<Student>
            {
                new Student("Joni", 6),
                new Student("Petur", 4),
                new Student("Gosho", 5),
                new Student("Tosho", 3)
            };

            foreach (var students in student)
            {
                Console.WriteLine(students);
            }

        }
    }
}
