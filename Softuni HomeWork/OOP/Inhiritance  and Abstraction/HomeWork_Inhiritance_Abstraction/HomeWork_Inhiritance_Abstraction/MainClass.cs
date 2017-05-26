using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork_Inhiritance_Abstraction.Human;

namespace HomeWork_Inhiritance_Abstraction.Human
{
    class MainClass
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>()
            {
                new Student("Alex","Mihov","AABB01"),
                new Student("Den","Man","AABB02"),
                new Student("George","Djo","AABB03"),
                new Student("Vik","Per","AABB04"),
                new Student("Gesh","Man","AABB05"),
                new Student("Sham","Duh","AABB06"),
                new Student("Alex","New","AABB07"),
                new Student("Boji","Fam","AABB08"),
                new Student("Gen","Ily","AABB09"),
                new Student("Ivan", "Mer", "AABB10")
           };

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Angi", "Black", 5409, 5),
                new Worker("Tor", "Black", 4999, 3),
                new Worker("Jen", "Jam", 3490,1),
                new Worker("Phoenix", "Mr", 8999, 7),
                new Worker("Fllen", "Dev", 100000, 8),
                new Worker("Faster", "Jen", 500000, 7),
                new Worker("Megn", "Foks", 45998, 8),
                new Worker("Sk", "Blz", 5700, 7),
                new Worker("Call", "Mah", 30000, 6),
                new Worker("As", "Kira", 30000, 5)
            };

            var sortedStudents = students.OrderBy(student => student.FacultyNumber);

            foreach (Student student in sortedStudents)
            {
                Console.WriteLine("Name: {0} {1},Faculty Number: {2}",student.FirstName,student.LastName,student.FacultyNumber);
            }
            Console.WriteLine();
            var sortedWorkers = workers.OrderByDescending(Worker => Worker.MoneyPerHour());

            foreach (Worker worker in sortedWorkers)
            {
                Console.WriteLine("Name: {0} {1}, Week Salary: {2}, Work Hours Per Day: {3}",worker.FirstName,worker.LastName,worker.WeekSalary,worker.WorkHoursPerDay);
            }

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortedHumans = humans.OrderBy(human => human.FirstName)
                .ThenBy(human => human.LastName);

            Console.WriteLine();

            foreach (Human human in humans)
            {
                Console.WriteLine("Name: {0} {1}",human.FirstName,human.LastName);
            }

        }
    }
}
