using AdvancedMapping.Models;
using System;
using System.Collections.Generic;

namespace AdvancedMapping
{
    public class AdvancedMappingApp
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Alex",
                    LastName = "Mihov",
                    Adress = "None",
                    Birthday = DateTime.Today,
                    Salary = 123.21m,
                    IsOnHoliday = true,
                    Manager = new Employee() {FirstName = "Josh", LastName = "Peterson"},
                    Employees = new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Alex",
                            LastName = "Mihov",
                            Adress = "None",
                            Birthday = DateTime.Today,
                            Salary = 123.21m,
                            IsOnHoliday = true,
                            Manager = new Employee() {FirstName = "Josh", LastName = "Peterson"},
                        }
                    }
                },
                 new Employee()
                {
                    FirstName = "Babam",
                    LastName = "Maeasd",
                    Adress = "Mvp",
                    Birthday = DateTime.Today,
                    Salary = 123.21m,
                    IsOnHoliday = true,
                    Manager = new Employee() {FirstName = "Noni", LastName = "Leaem"},
                    Employees = new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Dude",
                            LastName = "Where",
                            Adress = "Is my car",
                            Birthday = DateTime.Today,
                            Salary = 123.21m,
                            IsOnHoliday = true,
                            Manager = new Employee() {FirstName = "Pete", LastName = "Fury"},
                        }
                    }
                }
            };


        }
    }
}