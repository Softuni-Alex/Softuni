namespace Softuni.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Softuni.Data.Services;
    using Softuni.Models;

    class Program
    {
        static void Main()
        {
            UnitOfWork work = new UnitOfWork();

           EmployeesService service = new EmployeesService(work);
           Console.WriteLine(service.GetEmployeeByName("Guy").LastName);
           //SoftuniContext context=  new SoftuniContext();
           // context.Employees.FirstOrDefault(employee => employee.FirstName == "Guy");
        }
    }
}
