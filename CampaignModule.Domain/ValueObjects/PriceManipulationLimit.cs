using CampaignModule.Domain.Core;
using CampaignModule.Domain.Exceptions;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class PriceManipulationLimit : ValueObject
  {
    public double Value { get; private set; }

    public PriceManipulationLimit(double limit)
    {
      if (limit < 1)
      {
        throw new CustomValueObjectException("PriceManipulationLimit must be greater than zero.");
      }

      Value = limit;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
