using System.Collections.Generic;

namespace PizzaForum.Models
{
    public class Categorie
    {
        public Categorie()
        {
            this.Topics = new List<Topic>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
