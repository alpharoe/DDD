using VSI.BenefitPortal.Core.Entities;
using VSI.BenefitPortal.Core.SharedKennel;

namespace VSI.BenefitPortal.Core.Events
{
    public class EnrolleeEnrolmentCompletedEvent : BaseDomainEvent
    {
        public Enrollee CompletedEnrolmentEnrollee { get; set; }

        public EnrolleeEnrolmentCompletedEvent(Enrollee enrollee)
        {
            CompletedEnrolmentEnrollee = enrollee;
        }
    }
}