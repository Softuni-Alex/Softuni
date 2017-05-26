using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    class Program
    {
        static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, SortedDictionary<string, List<double>>>();
            for (int i = 0; i < count; i++)
            {
                var inputRow = Console.ReadLine();
                var student = inputRow.Split(' ');
                var fullName = student[0] + " " + student[1];
                var subject = student[2];
                var score = double.Parse(student[3]);
                if (students.ContainsKey(fullName))
                {
                    if (students[fullName].ContainsKey(subject))
                    {
                        students[fullName][subject].Add(score);
                    }
                    else
                    {
                        var scores = new List<double>();
                        scores.Add(score);
                        students[fullName].Add(subject, scores);
                    }
                }
                else
                {
                    var scores = new List<double>();
                        scores.Add(score);
                        var subjects = new SortedDictionary<string, List<double>>();
                        subjects.Add(subject, scores);
                    students.Add(fullName, subjects);
                }
            }
            foreach (var student in students)
            {
                var sub = student.Value.Select(x=> x.Key + " - " + x.Value.Average().ToString("0.00")).Aggregate((x, y)=> x + ", " + y);
                Console.WriteLine("{0}: [{1}]", student.Key, sub);
            }
        }
    }
}
