using System;

namespace VSI.BenefitPortal.Core.SharedKennel
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreCompareAttribute : Attribute
    {
    }
}