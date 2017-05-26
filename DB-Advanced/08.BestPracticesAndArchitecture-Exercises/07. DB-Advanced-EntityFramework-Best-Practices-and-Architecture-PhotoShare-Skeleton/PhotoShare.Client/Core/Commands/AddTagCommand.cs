using PhotoShare.Client.Utilities;
using System.Data.Entity;

namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Models;
    public class AddTagCommand : Command
    {
        [Insert]
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

        public AddTagCommand(string[] data) : base(data)
        {
        }

        //AddTag <tag>
        public override string Execute()
        {
            string tag = this.Data[1].ValidateOrTransform();

            this.tags.Add(new Tag
            {
                Name = tag
            });

            return tag + " was added sucessfully to database";
        }
    }
}
