using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Alex", 18);

            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine(
                    "Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName,
                    eventArgs.OldValue,
                    eventArgs.NewValue);
            };

            student.Name = "Alu";
            student.Age = 19;
        }
    }
}
