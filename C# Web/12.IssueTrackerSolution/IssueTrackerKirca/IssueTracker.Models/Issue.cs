namespace IssueTracker.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Issue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User Author { get; set; }
    }
}
