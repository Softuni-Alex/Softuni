namespace PhotoShare.Client.Core.Commands
{
    using Models;
    public class AddTownCommand : Command
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

        public AddTownCommand(string[] data) : base(data)
        {
        }

        //AddTown <townName> <countryName>
        public override string Execute()
        {
            string townName = this.Data[1];
            string country = this.Data[2];

            Town town = new Town()
            {
                Name = townName,
                Country = country
            };

            this.towns.Add(town);

            return townName + " was added to database";
        }
    }
}
