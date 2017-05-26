using BlobsOOP.Interfaces;

namespace BlobsOOP.Models.Attacks
{
    public abstract class BaseAttack : IAttack
    {
        public abstract void ExecuteAttack(IBlob target, int damage);

        public abstract void ExecuteEffectsOnAttacker(IBlob attacker);
    }
}
