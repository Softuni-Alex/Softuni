using BlobsOOP.Interfaces;
using BlobsOOP.Models;

namespace BlobsOOP.Engine.Factories
{
    public class BlobFactory : IBlobFactory
    {
        public IBlob Create(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            return new Blob(name, health, damage, behavior, attack);
        }
    }
}
