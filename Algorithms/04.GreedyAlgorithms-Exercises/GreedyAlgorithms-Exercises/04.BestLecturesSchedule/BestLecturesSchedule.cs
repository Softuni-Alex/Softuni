using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.BestLecturesSchedule
{
    public class BestLecturesSchedule
    {
        private const string Pattern = @"(?<lecture>\w+): (?<start>\d+) - (?<end>\d+)";

        public static void Main(string[] args)
        {
            int lecturesCount = int.Parse(Console.ReadLine().Substring(10));

            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), Pattern);
                string lectureName = match.Groups["lecture"].Value;
                int start = int.Parse(match.Groups["start"].Value);
                int end = int.Parse(match.Groups["end"].Value);
                Lecture lecture = new Lecture(lectureName, start, end);
                lectures.Add(lecture);
            }

            lectures = lectures.OrderBy(x => x.End).ToList();
            List<Lecture> result = new List<Lecture>();

            while (lectures.Count > 0)
            {
                Lecture last = lectures[0];
                result.Add(last);
                lectures = lectures.Where(lecture => lecture.Start >= last.End).ToList();
            }

            Console.WriteLine();
            Console.WriteLine("Lectures ({0}):", result.Count);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
    public class Lecture
    {
        public Lecture(string name, int start, int end)
        {
            this.Name = name;
            this.Start = start;
            this.End = end;
        }

        public string Name { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1} -> {2}", this.Start, this.End, this.Name);
        }
    }
}

