using BlobsOOP.Models.EventHandlers;

namespace BlobsOOP.Interfaces
{
    public interface IAttackable
    {
        void Respond(int damage);

        event EventHandler.BlobDeadEventHandler OnBlobDead;
    }
}
