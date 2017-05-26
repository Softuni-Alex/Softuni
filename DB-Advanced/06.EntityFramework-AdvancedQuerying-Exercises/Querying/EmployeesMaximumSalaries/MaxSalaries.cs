using System;

namespace EmployeesMaximumSalaries
{
    using System.Linq;

    public class MaxSalaries
    {
        public static void Main()
        {
            SoftuniContext context = new SoftuniContext();
            var departmentSalaries = context.Departments.Join(context.Employees,
                (d => d.DepartmentID),
                (e => e.DepartmentID),
                (d, e) => new
                {
                    Department = d.Name,
                    Salary = e.Salary
                })
                .Where(s => s.Salary < 30000 || s.Salary > 70000)
                .GroupBy(d => d.Department)
                .Select(x => x.Key);

            foreach (var departmentSalary in departmentSalaries)
            {
                Console.WriteLine($"{departmentSalary} -");
            }
        }
    }
}