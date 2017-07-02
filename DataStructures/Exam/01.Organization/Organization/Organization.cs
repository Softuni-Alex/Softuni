using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Organization : IOrganization
{
    private readonly Dictionary<string, HashSet<Person>> persons = new Dictionary<string, HashSet<Person>>();

    private readonly Dictionary<int, HashSet<Person>> indexedPersons = new Dictionary<int, HashSet<Person>>();
    private readonly Dictionary<int, Person> indexed = new Dictionary<int, Person>();
    private readonly List<Person> personList = new List<Person>();

    public int Count
    {
        get { return this.persons.Count; }
    }

    public void Add(Person person)
    {
        //TODO: check if key present
        var hashSet = new HashSet<Person> { person };

        if (!this.persons.ContainsKey(person.Name))
        {
            this.persons.Add(person.Name, hashSet);
        }

        this.indexedPersons.Add(this.indexedPersons.Count + 1, hashSet);

        this.indexed.Add(this.indexed.Count + 1, person);

        this.personList.Add(person);
    }

    public bool Contains(Person person)
    {
        //check indexedPersons
        if (this.persons.ContainsKey(person.Name))
        {
            var desired = this.persons[person.Name];

            return true;
        }

        return false;
    }

    public bool ContainsByName(string name)
    {
        if (this.persons.ContainsKey(name))
        {
            return true;
        }

        return false;
    }

    public Person GetAtIndex(int index)
    {
        if (index == 0)
        {
            if (this.indexedPersons.ContainsKey(index + 1))
            {
                var person = this.indexed[index + 1];

                return person;
            }
        }

        if (this.indexedPersons.ContainsKey(index))
        {
            var person = this.indexed[index + 1];

            return person;
        }

        throw new IndexOutOfRangeException();
    }

    public IEnumerable<Person> GetByName(string name)
    {
        var persons = this.personList.Where(x => x.Name == name);

        return persons;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in this.persons.Values)
        {
            foreach (var item in person)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        if (this.indexed.Count < count)
        {
            var persons = this.indexed.Values.Take(this.indexed.Count);

            return persons;
        }
        if (this.indexed.Count >= count)
        {
            var persons = this.indexed.Values.Take(count);

            return persons;
        }

        return new List<Person>();
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        List<Person> personList = new List<Person>();

        foreach (var persons in this.indexedPersons.Values)
        {
            foreach (var person in persons)
            {
                if (person.Name.Length >= minLength && person.Name.Length <= maxLength)
                {
                    personList.Add(person);
                }
            }
        }

        return personList;
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        var persons = new List<Person>();

        foreach (var personsValue in this.indexedPersons.Values)
        {
            foreach (var person in personsValue)
            {
                if (person.Name.Length == length)
                {
                    persons.Add(person);
                }
            }
        }

        if (persons.Count == 0)
        {
            throw new ArgumentException();
        }

        return persons;
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        var personList = new List<Person>();

        foreach (var personValues in this.persons.Values)
        {
            foreach (var person in personValues)
            {
                personList.Add(person);
            }
        }

        return personList;
    }
}