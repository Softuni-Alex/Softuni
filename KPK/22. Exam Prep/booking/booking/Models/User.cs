﻿namespace HotelBookingSystem.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using Utilities;

    public class User : IDbEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinUsernameLenght)
                {
                    throw new ArgumentException(string.Format("The username must be at least {0} symbols long.", Constants.MinUsernameLenght));
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get { return this.passwordHash; }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinPasswordLenght)
                {
                    throw new ArgumentException(string.Format("The password must be at least {0} symbols long.", Constants.MinPasswordLenght));
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}
