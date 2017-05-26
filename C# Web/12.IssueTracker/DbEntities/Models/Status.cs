using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbEntities.Models
{
    public class Status
    {
        public Status()
        {
            this.Issues = new HashSet<Issue>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
