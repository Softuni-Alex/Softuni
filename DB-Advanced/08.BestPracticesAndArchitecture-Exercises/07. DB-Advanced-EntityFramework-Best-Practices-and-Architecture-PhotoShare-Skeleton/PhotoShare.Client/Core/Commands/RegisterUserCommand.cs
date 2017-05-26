namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    public class RegisterUserCommand : Command
    {
        [Inject]
        private PhotoShareContext context;
        [Inject]
        private DbSet<User> users;
        [Inject]
        private DbSet<Album> albums;
        [Inject]
        private DbSet<Picture> pictures;
        [Inject]
        private DbSet<Tag> tags;
        [Inject]
        private DbSet<AlbumRole> albumRoles;
        [Inject]
        private DbSet<Town> towns;

        public RegisterUserCommand(string[] data) : base(data)
        {
        }

        //RegisterUser <username> <password> <repeat-password> <email>
        public override string Execute()
        {
            string username = this.Data[1];
            string password = this.Data[2];
            string repeatPassword = this.Data[3];
            string email = this.Data[4];
            if (password == rереatPаsswоrd)
            {
                throw new InvalidOperationException("Passwords does not match");
            }

            User user = new User()
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            this.users.Add(user);
            this.context.SaveChanges();
            return "User " + user.Username + " was registered sucesfully";
        }
    }
}
