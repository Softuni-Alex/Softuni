using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Company
{
    using Interfaces;
    using Enums;

    class Manager:Employee,IManager
    {

        public Manager(int id,string firstName,string lastName,Departments department,decimal salary,List<IEmployee> employeesManagers)
            :base(id,firstName,lastName,salary,department)
        {
            this.EmployeeManagers = employeesManagers;
        }

        public Manager(int id,string firstName,string lastName,Departments department,decimal salary,IEmployee employeeManagers)
            : this(id, firstName, lastName, department, salary, new List<IEmployee> { employeeManagers})
        {

        }

        public List<IEmployee> EmployeeManagers { get;private set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("Role: Manager\n");
            result += string.Format("Employees managed: ");

            List<string> employeeNames = new List<string>();
            foreach (Employee employee in this.EmployeeManagers)
            {
                employeeNames.Add(string.Format("{0} {1}", employee.FirstName, employee.LastName));
            }

            result += string.Join(", ", employeeNames) + "\n";

            return result;
        }
    }
}
