using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGrades
{
    public class AverageGrades
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];

                var grades = input.Skip(1).Take(input.Length - 1).Select(double.Parse).ToList();

                Student student = new Student();
                student.Name = name;
                student.Grades = grades;

                students.Add(student);
            }

            var result =
               students.Where(x => x.AverageGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

            foreach (var student in result)
            {
                Console.WriteLine("{0} -> {1:f2}", student.Name, student.AverageGrade);
            }
        }
    }
}