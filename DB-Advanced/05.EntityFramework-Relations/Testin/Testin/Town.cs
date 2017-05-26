using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testin
{
    public class Town
    {
        public Town()
        {
            this.BornPeople = new HashSet<People>();
            this.LivingPeople = new List<People>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("BornTown")]
        public ICollection<People> BornPeople { get; set; }

        [InverseProperty("LivingTown")]
        public ICollection<People> LivingPeople { get; set; }
    }
}