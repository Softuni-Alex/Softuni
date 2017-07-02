using System.Collections.Generic;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private SortedDictionary<int, SortedSet<Person>> personsByAge = new SortedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, SortedDictionary<int, SortedSet<Person>>> personsByTownAndAge = new Dictionary<string, SortedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            //already exist
            return false;
        }

        var person = new Person()
        {
            Email = email,
            Age = age,
            Town = town,
            Name = name
        };

        this.personsByEmail.Add(email, person);

        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        var nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        this.personsByAge.AppendValueToKey(age, person);

        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];

        return domain;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        Person person;

        var isExist = this.personsByEmail.TryGetValue(email, out person);

        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        if (person == null)
        {
            return false;
        }

        this.personsByEmail.Remove(email);

        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        this.personsByAge[person.Age].Remove(person);

        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personsByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);

        return this.personsByNameAndTown.GetValuesForKey(nameAndTown);
    }

    private string CombineNameAndTown(string name, string town)
    {
        string separator = "|!|";

        return name + separator + town;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        //var personsInRange = this.personsByAge.(startAge, true, endAge, true);

        //foreach (var personsByAge in personsInRange)
        //{
        //    foreach (var person in personsByAge.Value)
        //    {
        //        yield return person;
        //    }
        //}

        return null;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var personsInRange = this.personsByTownAndAge[town];

    }
}
