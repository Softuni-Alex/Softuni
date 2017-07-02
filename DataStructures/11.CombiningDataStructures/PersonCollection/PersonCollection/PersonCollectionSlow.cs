﻿using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private readonly List<Person> persons = new List<Person>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        var containsEmail = this.persons.Any(p => p.Email == email);

        if (containsEmail)
        {
            return false;
        }

        var person = new Person()
        {
            Age = age,
            Email = email,
            Name = name,
            Town = town
        };

        try
        {
            this.persons.Add(person);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return false;
        }
    }

    public int Count
    {
        get { return this.persons.Count; }
    }

    public Person FindPerson(string email)
    {
        var person = this.persons.Find(p => p.Email == email);

        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.persons.FirstOrDefault(p => p.Email == email);

        if (person != null)
        {
            this.persons.Remove(person);
            return true;
        }

        return false;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var persons = this.persons
            .FindAll(p => p.Email
                .EndsWith("@" + emailDomain))
            .OrderBy(p => p.Email);

        return persons;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var persons = this.persons
            .FindAll(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email);

        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var persons = this.persons
            .FindAll(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        return persons;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        var persons = this.persons.FindAll(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        return persons;
    }
}
