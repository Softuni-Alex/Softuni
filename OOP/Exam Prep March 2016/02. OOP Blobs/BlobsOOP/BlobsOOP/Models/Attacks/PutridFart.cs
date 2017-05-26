using BlobsOOP.Interfaces;

namespace BlobsOOP.Models.Attacks
{
    public class PutridFart : BaseAttack
    {
        public override void ExecuteAttack(IBlob target, int damage)
        {
            target.Respond(damage);
        }

        public override void ExecuteEffectsOnAttacker(IBlob attacker)
        {
        }
    }
}
