using System;

namespace VSI.BenefitPortal.Core.SharedKennel
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
    }
}