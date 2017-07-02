using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enterprise : IEnterprise
{
    private readonly Dictionary<Guid, Employee> nonCollection = new Dictionary<Guid, Employee>();

    public int Count
    {
        get { return this.nonCollection.Count; }
    }

    public bool Contains(Guid guid)
    {
        if (this.nonCollection.ContainsKey(guid))
        {
            return true;
        }

        return false;
    }

    public bool Contains(Employee employee)
    {
        if (this.nonCollection.ContainsKey(employee.Id))
        {
            return true;
        }

        return false;
    }

    public void Add(Employee employee)
    {
        if (!this.nonCollection.ContainsKey(employee.Id))
        {
            this.nonCollection.Add(employee.Id, employee);
        }
    }

    public bool Fire(Guid guid)
    {
        if (this.nonCollection.ContainsKey(guid))
        {
            return this.nonCollection.Remove(guid);
        }

        return false;
    }

    public Employee GetByGuid(Guid guid)
    {
        if (this.nonCollection.ContainsKey(guid))
        {
            var employee = this.nonCollection[guid];

            return employee;
        }

        throw new ArgumentException();
    }

    public bool Change(Guid guid, Employee employee)
    {
        if (this.nonCollection.ContainsKey(guid))
        {
            var person = this.nonCollection[guid];

            person = employee;

            this.nonCollection[guid] = person;

            return true;
        }

        return false;
    }

    public Position PositionByGuid(Guid guid)
    {
        if (this.nonCollection.ContainsKey(guid))
        {
            var employee = this.nonCollection[guid];

            return employee.Position;
        }

        throw new InvalidOperationException();
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        foreach (var employees in this.nonCollection.Values)
        {
            yield return employees;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        var list = new List<Employee>();

        foreach (var employeesValue in this.nonCollection.Values)
        {
            if (employeesValue.Position == position)
            {
                list.Add(employeesValue);
            }
        }

        if (list.Count > 0)
        {
            return list;
        }

        throw new ArgumentException();
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        var list = new List<Employee>();

        foreach (var employeeValues in this.nonCollection.Values)
        {
            if (employeeValues.Salary >= minSalary)
            {
                list.Add(employeeValues);
            }
        }

        if (list.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return list;
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        var list = new List<Employee>();

        foreach (var employeeValues in this.nonCollection.Values)
        {
            if (employeeValues.Salary == salary && employeeValues.Position == position)
            {
                list.Add(employeeValues);
            }
        }

        if (list.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return list;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        var list = new List<Employee>();

        foreach (var employee in this.nonCollection.Values)
        {
            if (employee.FirstName == firstName)
            {
                list.Add(employee);
            }
        }

        return list;
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        var list = new List<Employee>();

        foreach (var employeeValues in this.nonCollection.Values)
        {
            if (employeeValues.Salary >= minSalary && employeeValues.Position == position)
            {
                list.Add(employeeValues);
            }
        }

        if (list.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return list;
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        var list = new List<Employee>();

        foreach (var employeeValues in this.nonCollection.Values)
        {
            if (employeeValues.Salary >= minSalary && employeeValues.Salary <= maxSalary)
            {
                list.Add(employeeValues);
            }
        }

        return list;
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        var list = new List<Employee>();
        foreach (var position in positions)
        {
            foreach (var employeesValue in this.nonCollection.Values)
            {
                if (position == employeesValue.Position)
                {
                    list.Add(employeesValue);
                }
            }
        }

        return list;
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        var list = new List<Employee>();

        foreach (var employeeValues in this.nonCollection.Values)
        {
            if (employeeValues.FirstName == firstName && employeeValues.LastName == lastName && employeeValues.Position == position)
            {
                list.Add(employeeValues);
            }
        }

        return list;
    }

    public bool RaiseSalary(int months, int percent)
    {
        foreach (var employeeValues in this.nonCollection.Values)
        {
            var monthDifference = DateTime.Today.Month - employeeValues.HireDate.Month;
            if (employeeValues.HireDate.Month > monthDifference)
            {
                employeeValues.Salary = employeeValues.Salary * percent / 100;
            }

            return true;
        }

        return false;
    }
}