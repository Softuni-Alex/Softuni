using System;
using System.Collections.Generic;

public class Launcher
{
    public static void Main()
    {
        IEnterprise enterprise = new Enterprise();

        DateTime calendar = new DateTime(2017, 1, 1);
        Employee employee = new Employee("pesho", "123", 777, Position.Hr, calendar);
        Employee employee1 = new Employee("a", "321", 777, Position.Owner, calendar);
        Employee employee2 = new Employee("c", "111", 777, Position.Hr, calendar);
        Employee employee3 = new Employee("b", "11111", 777, Position.Developer, calendar);

        enterprise.Add(employee);
        enterprise.Add(employee1);
        enterprise.Add(employee2);
        enterprise.Add(employee3);

        bool b = enterprise.RaiseSalary(1, 50);

        IEnumerable<Employee> bySalary = enterprise.GetBySalary(1165.5);

        List<string> employeesNames = new List<string>();
        foreach (Employee employee4 in bySalary)
        {
            employeesNames.Add(employee4.FirstName);
        }


        employeesNames.Sort();

        string[] expected = new string[] { "a", "b", "c", "pesho" };
        int idx = 0;

    }
}
