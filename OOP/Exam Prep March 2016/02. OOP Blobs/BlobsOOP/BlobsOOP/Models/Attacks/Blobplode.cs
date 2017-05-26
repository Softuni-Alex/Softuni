using BlobsOOP.Interfaces;

namespace BlobsOOP.Models.Attacks
{
    public class Blobplode : BaseAttack
    {
        public override void ExecuteAttack(IBlob target, int damage)
        {
            damage = damage * 2;
            target.Respond(damage);
        }

        public override void ExecuteEffectsOnAttacker(IBlob attacker)
        {
            attacker.Health -= attacker.Health / 2;
        }
    }
}
