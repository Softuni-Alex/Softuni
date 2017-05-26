using System;
using System.Collections.Generic;

namespace PizzaForum.Models
{
    public class Topic
    {
        public Topic()
        {
            this.Replies = new List<Replie>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual ICollection<Replie> Replies { get; set; }
    }
}
