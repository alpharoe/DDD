using System;
using VSI.BenefitPortal.Core.SharedKennel;
using VSI.BenefitPortal.Core.Events;

namespace VSI.BenefitPortal.Core.Entities
{
    public class Enrollee : Entity
    {
        #region Anemic properties 
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public DateTime? DOB { get; set; }
        #endregion

        public bool IsCompletedEnrollment { get; set; }

        public void EnrollmentCompleted()
        {
            IsCompletedEnrollment = true;
            Events.Add(new EnrolleeEnrolmentCompletedEvent(this));
        }
    }
}