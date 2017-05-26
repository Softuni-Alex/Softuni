namespace SimpleMapping
{
    using AutoMapper;
    using Dto;
    using Models;
    using System;

    public class SimpleMappingApp
    {
        public static void Main()
        {
            Mapper.Initialize(map => map.CreateMap<Employee, EmployeeDto>());

            var employee = new Employee()
            {
                FirstName = "Alex",
                LastName = "Mihov",
                Adress = "None",
                Birthday = DateTime.Today,
                Salary = 123.21m
            };

//            var dto = Mapper.Map<EmployeeDto>(employee);

            Console.WriteLine(employee.FirstName);
        }
    }
}