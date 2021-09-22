using CampaignModule.Domain.Core;
using CampaignModule.Domain.Exceptions;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class TargetSalesCount : ValueObject
  {
    public double Value { get; private set; }

    public TargetSalesCount(double salesCount)
    {
      if (salesCount < 1)
      {
        throw new CustomValueObjectException("TargetSalesCount must be greater than zero.");
      }

      Value = salesCount;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
