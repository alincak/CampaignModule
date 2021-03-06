using CampaignModule.Domain.Core;
using CampaignModule.Domain.Exceptions;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class Quantity : ValueObject
  {
    public double Value { get; private set; }

    public Quantity(double quantity)
    {
      if (quantity < 1)
      {
        throw new CustomValueObjectException("Quantity must be greater than zero.");
      }

      Value = quantity;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
