namespace Huy_Phuong.Models
{
    using Interfaces;
    using System;

    public class Theatre : ITheatre
    {
        public Theatre(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            string theatreAsString = this.Name;
            return theatreAsString;
        }

        public int CompareTo(Object other)
        {
            var otherTheatre = other as ITheatre;
            int result = this.Name.CompareTo(otherTheatre.Name);
            return result;
        }
    }
}
