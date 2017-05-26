using System.Linq;

namespace EntityFrameworkExercises
{
    using Models;
    using System;

    public class DbApp
    {
        private static readonly SoftuniDbContext softuni = new SoftuniDbContext();

        public static void Main()
        {
            //03.
            //                            var employees = softuni.Employees;
            //            
            //                            foreach (var employee in employees)
            //                            {
            //                                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            //                            }

            //04.
            //Console.WriteLine(string.Join("\n", softuni.Employees.Where(x => x.Salary > 50000).Select(x => x.FirstName)));

            //05.
            //            var employees = softuni.Employees.Where(emp => emp.Department.Name == "Research and Development").OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName);
            //
            //            foreach (var employee in employees)
            //            {
            //                Console.WriteLine($"{employee.FirstName} {employee.LastName}" + $" from {employee.Department.Name} - ${employee.Salary:F2}");
            //            }

            //06.
            //                        Address address = new Address()
            //                        {
            //                            AddressText = "Vitoshka 15",
            //                            TownID = 4
            //                        };
            //            
            //                        Employee neededEmployee = softuni.Employees.SingleOrDefault(emp => emp.LastName == "Nakov");
            //                        neededEmployee.Address = address;
            //            
            //                        softuni.SaveChanges();
            //            
            //                        var employees = softuni.Employees.OrderByDescending(emp => emp.AddressID)
            //                                .Take(10)
            //                                .Select(emp => emp.Address.AddressText);
            //            
            //                        foreach (var employee in employees)
            //                        {
            //                            Console.WriteLine(employee);
            //                        }

            //07.
            //            var projectToRemove = softuni.Projects.Find(2);
            //
            //            var employee = softuni.Employees;
            //
            //            foreach (var employee1 in employee)
            //            {
            //                employee1.Projects.Remove(projectToRemove);
            //            }
            //            softuni.SaveChanges();
            //
            //            softuni.Projects.Remove(projectToRemove);
            //
            //            softuni.SaveChanges();
            //
            //            var projects = softuni.Projects.Take(10).Select(proj => proj.Name);
            //
            //            foreach (var project in projects)
            //            {
            //                Console.WriteLine(project);
            //            }

            //08.
            //            var employees =
            //                softuni.Employees
            //                .Where(emp => emp.Projects
            //                .Count(proj => proj.StartDate.Year >= 2001 && proj.StartDate.Year <= 2003) > 0)
            //                .Take(30);
            //
            //            foreach (var employee in employees)
            //            {
            //                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");
            //                foreach (var project in employee.Projects)
            //                {
            //                    Console.WriteLine($"--{project.Name} {project.StartDate.ToString("M'/'d'/'yyyy h:mm:ss tt")} {project.EndDate?.ToString("M'/'d'/'yyyy h:mm:ss tt")}");
            //                }
            //            }

            //09.
            //            var addresses = softuni.Addresses
            //                    .OrderByDescending(address => address.Employees.Count)
            //                    .ThenBy(x => x.Town.Name)
            //                    .Take(10);
            //
            //            foreach (var address in addresses)
            //            {
            //                Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            //            }

            //10.
            //            var employee = softuni.Employees.Where(emp => emp.EmployeeID == 147);
            //
            //            foreach (var emp in employee)
            //            {
            //                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
            //                foreach (var project in emp.Projects.OrderBy(proj => proj.Name))
            //                {
            //                    Console.WriteLine(project.Name);
            //                }
            //            }

            //11.
            //            var departments =
            //                softuni.Departments.Where(dep => dep.Employees.Count > 5).OrderBy(emp => emp.Employees.Count);
            //
            //            foreach (var department in departments)
            //            {
            //                Console.WriteLine($"{department.Name} {department.Employee.FirstName}");
            //                foreach (var employee in department.Employees)
            //                {
            //                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //                }
            //            }

            //12.
            //            var timer = new Stopwatch();
            //            timer.Start();
            //            PrintNamesWithNativeQuery(softuni);
            //            timer.Stop();
            //            Console.WriteLine($"Native: {timer.Elapsed}");
            //
            //            timer.Restart();
            //            PrintNamesWithLinq(softuni);
            //            timer.Stop();
            //            Console.WriteLine($"Linq: {timer.Elapsed}");

            //15.
            //            var tenProjects = softuni.Projects.OrderByDescending(proj => proj.StartDate).Take(10).OrderBy(p => p.Name);
            //            foreach (var tenProject in tenProjects)
            //            {
            //                Console.WriteLine($"{tenProject.Name} {tenProject.Description} {tenProject.StartDate.ToString("M'/'d'/'yyyy h:mm:ss tt")} {tenProject.EndDate?.ToString("M'/'d'/'yyyy h:mm:ss tt")}");
            //            }
            //            //remove the white spaces... judge ...

            //16.
            //            var employees = softuni.Employees.Where(emp => emp.Department.Name == "Engineering" ||
            //                                                           emp.Department.Name == "Tool Design" ||
            //                                                           emp.Department.Name == "Marketing" ||
            //                                                           emp.Department.Name == "Information Services");
            //
            //            foreach (var employee in employees)
            //            {
            //                employee.Salary *= 1.12m;
            //                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f6})");
            //            }
            //            softuni.SaveChanges();

            //17.
            string townToDelete = Console.ReadLine();

            var myTown = softuni.Towns.FirstOrDefault(town => town.Name.Equals(townToDelete));

            var addressesToDelete = softuni.Addresses.FirstOrDefault(ad => ad.Town.Name.Equals(townToDelete));

            var employeesToDelete =
                 softuni.Employees.Where(emp => emp.Address.AddressID.Equals(addressesToDelete.AddressID));

            foreach (var employee in employeesToDelete)
            {
                employee.AddressID = null;
            }

            softuni.Addresses.Remove(addressesToDelete);

            softuni.Towns.Remove(myTown);

            softuni.SaveChanges();

            //18.FIRST WAY - easiest
            //            var employees = softuni.Employees.Where(emp => emp.FirstName.StartsWith("SA"));
            //            foreach (var employee in employees)
            //            {
            //                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            //            }

            //SECOND WAY - the long one
            //            var employees = softuni.Employees.ToList();
            //
            //            for (int i = 0; i < employees.Count; i++)
            //            {
            //                string concat = "";
            //                char firstLetter = ' ';
            //                char secondLetter = ' ';
            //                if (employees[i].FirstName.Length >= 2 && employees[i].FirstName != null)
            //                {
            //                    firstLetter = employees[i].FirstName[0];
            //                    secondLetter = employees[i].FirstName[1];
            //
            //                    concat = "" + firstLetter + secondLetter;
            //                }
            //                else
            //                {
            //                    Console.WriteLine("The word is tooo short!");
            //                }
            //
            //                if (concat.ToLower().Contains("sa"))
            //                {
            //                    Console.WriteLine($"{employees[i].FirstName} {employees[i].LastName} - {employees[i].JobTitle} - (${employees[i].Salary})");
            //                }
            //            }

            Console.ReadKey();
        }

        //for ex 12.
        //        private static void PrintNamesWithLinq(SoftuniDbContext softuni)
        //        {
        //            var employees = softuni.Employees.Where(emp => emp.Projects.Count(proj => proj.StartDate.Year > 2002) > 0).Select(emp => emp.FirstName);
        //
        //            Console.WriteLine(string.Join(" ", employees));
        //        }
        //
        //        private static void PrintNamesWithNativeQuery(SoftuniDbContext softuni)
        //        {
        //            const string query = "SELECT e.FirstName FROM Employees AS e " +
        //                                 "INNER JOIN EmployeesProjects AS ep " +
        //                                 "ON ep.EmployeeID = e.EmployeeID " +
        //                                 "INNER JOIN Projects AS p " +
        //                                 "ON p.ProjectID = ep.ProjectID " +
        //                                 "WHERE YEAR(p.StartDate) > 2002";
        //
        //            var employees = softuni.Database.SqlQuery<string>(query).ToList();
        //
        //            Console.WriteLine(string.Join(" ", employees));
        //    }
    }
}