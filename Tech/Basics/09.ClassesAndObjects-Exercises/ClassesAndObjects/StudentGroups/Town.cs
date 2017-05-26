using System.Collections.Generic;

namespace StudentGroups
{
    public class Town
    {
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public List<Student> Students { get; set; }
    }
}