using DbEntities.Models;

namespace RepositoryLayer.Interfaces
{
    public interface ISoftuniStoreData
    {
        IRepository<User> User { get; }

        IRepository<Game> Games { get; }

        IRepository<Login> Logins { get; }

        int SaveChanges();

        int ExecuteSqlCommand(string command);
    }
}
