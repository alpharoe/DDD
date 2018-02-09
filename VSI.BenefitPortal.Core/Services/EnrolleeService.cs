using VSI.BenefitPortal.Core.Events;
using VSI.BenefitPortal.Core.Interfaces;

namespace VSI.BenefitPortal.Core.Services
{
    public class EnrolleeService : IHandle<EnrolleeEnrolmentCompletedEvent>
    {
        public void Handle(EnrolleeEnrolmentCompletedEvent domainEvent)
        {
            // Do something when enrollee finishs enrolment
        }
    }
}