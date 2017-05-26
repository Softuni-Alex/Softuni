using BlobsOOP.Models.EventHandlers;

namespace BlobsOOP.Interfaces
{
    public interface IBlob : IAttackable, IAttacker, IUpdateable
    {
        string Name { get; }

        int Health { get; set; }

        int Damage { get; set; }

        bool IsAlive { get; }

        IBehavior Behavior { get; }

        IAttack Attack { get; }

        event EventHandler.BehaviorToggledEventHandler OnBehaviorToggled;
    }
}