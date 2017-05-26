namespace PetShopDB.Models
{
    using System;

    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime BirthDate { get; set; }
    }
}