using HotelBookingSystem.Utilities;

namespace HotelBookingSystem.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class Venue : IDbEntity
    {
        private string name;
        private string address;

        public Venue(string name, string address, string description, User owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinVenueNameLenght)
                {
                    throw new ArgumentException(string.Format("The venue name must be at least {0} symbols long.", Constants.MinVenueNameLenght));
                }
            }
        }

        public string Address
        {
            get { return this.address; }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinVenueAddressLenght)
                {
                    throw new ArgumentException(string.Format("The venue address must be at least {0} symbols long.", Constants.MinVenueAddressLenght));
                }

                this.address = value;
            }
        }

        public string Description { get; set; }

        public User Owner { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
