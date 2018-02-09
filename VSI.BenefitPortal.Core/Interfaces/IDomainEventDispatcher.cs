using VSI.BenefitPortal.Core.SharedKennel;

namespace VSI.BenefitPortal.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}