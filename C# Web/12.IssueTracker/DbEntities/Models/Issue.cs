using System;

namespace DbEntities.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PriorityId { get; set; }

        public Priority Priority { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        //   [Required,Column(TypeName = "Date")]
        public DateTime CreationDate { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}
