using System;
using System.Collections.Generic;
using System.Text;
using VSI.BenefitPortal.Core.SharedKennel;

namespace VSI.BenefitPortal.Core.Entities
{
    public class Dependent : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
