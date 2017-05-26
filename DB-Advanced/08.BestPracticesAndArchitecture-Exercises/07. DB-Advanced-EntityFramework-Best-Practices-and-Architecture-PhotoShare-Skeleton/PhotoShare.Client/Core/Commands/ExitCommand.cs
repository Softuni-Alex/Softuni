namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand : Command
    {
        //[Inject]
        //private PhotoShareContext context;
        //[Inject]
        //private DbSet<User> users;
        //[Inject]
        //private DbSet<Album> albums;
        //[Inject]
        //private DbSet<Picture> pictures;
        //[Inject]
        //private DbSet<Tag> tags;
        //[Inject]
        //private DbSet<AlbumRole> albumRoles;
        //[Inject]
        //private DbSet<Town> towns;

        public ExitCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "Bye-bye";
        }
    }
}
