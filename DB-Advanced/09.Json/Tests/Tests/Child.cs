namespace Tests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Child
    {
        public Child()
        {

        }

        public Child(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Children = new List<Child>();
        }

        public int Id { get; set; }

        [JsonProperty("User")]
        public string Name { get; set; }

        [JsonIgnore]
        public int Age { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}