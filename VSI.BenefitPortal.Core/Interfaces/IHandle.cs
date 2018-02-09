using VSI.BenefitPortal.Core.SharedKennel;

namespace VSI.BenefitPortal.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}