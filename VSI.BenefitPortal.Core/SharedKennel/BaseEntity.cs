using System.Collections.Generic;

namespace VSI.BenefitPortal.Core.SharedKennel
{
    // Modify this to TId to support Guid
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}