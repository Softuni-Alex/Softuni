using BlobsOOP.Interfaces;
using System;

namespace BlobsOOP.Models.Behaviours
{
    public class Inflated : BaseBehavior
    {
        private const int HealthBonus = 50;
        private const int HealthLostValue = 10;

        public override void Trigger(IBlob blob)
        {
            if (this.AlreadyTriggered)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }

            this.IsTriggered = true;
            this.AlreadyTriggered = true;
            blob.Health += HealthBonus;
        }

        public override void PerformNegativeEffects(IBlob blob)
        {
            if (this.ShouldDelayBeforeExecution)
            {
                this.ShouldDelayBeforeExecution = false;
            }
            else
            {
                blob.Health -= HealthLostValue;
            }
        }
    }
}
