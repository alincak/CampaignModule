using CampaignModule.Domain.Core;
using System;
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
        throw new Exception("PriceManipulationLimit must be greater than zero.");
      }

      Value = limit;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
