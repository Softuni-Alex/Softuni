namespace Softuni.Data.Services
{
    using System;
    using System.Linq;
    using Softuni.Models;
    public class EmployeesService
    {
        private readonly UnitOfWork unit;
        public EmployeesService(UnitOfWork unit)
        {
            this.unit = unit;
        }

        public Employee GetEmployeeByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name should not be null or empty!");
            }

            return this.unit.Employees.FindAll(employee => employee.FirstName == name).FirstOrDefault();
        }
    }
}
