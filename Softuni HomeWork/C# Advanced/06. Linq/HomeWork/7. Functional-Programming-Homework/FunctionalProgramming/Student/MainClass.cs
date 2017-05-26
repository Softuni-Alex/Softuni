using static System.String;

namespace Student
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<int> studentMarks = new List<int>();

            students.Add(new Student("Alex", "Mihov", 19, 12324356, "+35974352", "Alex@abv.bg", 2, rg.n));
            students.Add(new Student("Deni", "Man", 16, 42534534, "+025674352", "Deni@gmail.com", 1, studentMarks));
            students.Add(new Student("Demi", "Lovato", 24, 34546354, "+359274352", "Demi@abv.bg", 4, studentMarks));
            students.Add(new Student("Mark", "Zuckerberg", 28, 12456, "+35974352", "Mark@facebook.com", 1, studentMarks));
            students.Add(new Student("Selena", "Mine", 23, 546756, "+359 2674352", "Seli@abv.bg", 7, studentMarks));
            students.Add(new Student("Goshko", "Peshkov", 14, 34536, "+767866", "Goshko@kochina.bg", 2, studentMarks));
            students.Add(new Student("Letme", "Loveyou", 14, 124564356, "+0567654352", "Letme@yahoo.bg", 1, studentMarks));
            students.Add(new Student("Nana", "California", 99, 123452356, "+668674352", "California@abv.bg", 7,
                studentMarks));

            //Problem01
            var groupedStudents = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            foreach (var groupedStudent in groupedStudents)
            {
                Console.WriteLine("{0} from group number {1}", groupedStudent.FirstName, groupedStudent.GroupNumber);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Problem02
            var studentsByFirstName = students.Where(s => Compare(s.FirstName, s.LastName, StringComparison.OrdinalIgnoreCase) < 0) // Filter students whose FirstName is before LastName
                                              .OrderBy(s => s.FirstName) // Order by FirstName
                                              .ThenBy(s => s.LastName); // If FirstNames are equal, then order by LastName

            foreach (var studentByFirstName in studentsByFirstName)
            {
                Console.WriteLine("{0}, {1}", studentByFirstName.FirstName, studentByFirstName.LastName);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Problem03
            var ageFinder = students.Where(s => s.Age >= 18 && s.Age <= 24);

            foreach (var ageFind in ageFinder)
            {
                Console.WriteLine("Age: {0} Name: {1} LastName: {2}", ageFind.Age, ageFind.FirstName, ageFind.LastName);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Problem04
            var sortStudents = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            foreach (var sortStudent in sortStudents)
            {
                Console.WriteLine("First name: {0} Last name: {1}", sortStudent.FirstName, sortStudent.LastName);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Problem05
            var emailFilter = students.Where(x => x.Email.Contains("abv.bg"));

            foreach (var containsAbv in emailFilter)
            {
                Console.WriteLine("Emails containing abv.bg: {0}", containsAbv.Email);
            }

            Console.WriteLine();
            Console.WriteLine();

            var phoneFilter =
                students.Where(x => x.Phone.StartsWith("+02") || x.Phone.StartsWith("+3592") || x.Phone.StartsWith("+359 2"));

            foreach (var phoneFilters in phoneFilter)
            {
                Console.WriteLine("Phone starting with: {0}", phoneFilters.Phone);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Problem07


        }
    }
}