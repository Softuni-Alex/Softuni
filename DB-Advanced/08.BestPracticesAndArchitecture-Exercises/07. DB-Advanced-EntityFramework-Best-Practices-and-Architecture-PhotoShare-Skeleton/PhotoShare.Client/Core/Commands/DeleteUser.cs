namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;
    public class DeleteUser : Command
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

        public DeleteUser(string[] data) : base(data)
        {
        }

        //DeleteUser <username>
        public override string Execute()
        {
            //TODO Delete User by username (only mark him as inactive)
            string username = this.Data[1];
            var user = this.users
                .Where(u => u.Username == username)
                .FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException($"User with {username} was not found");
            }

            user.IsDeleted = true;
            this.context.SaveChanges();

            return $"User {username} was deleted from the databse";
        }
    }
}
