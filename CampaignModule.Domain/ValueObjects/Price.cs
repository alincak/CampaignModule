using CampaignModule.Domain.Core;
using CampaignModule.Domain.Exceptions;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class Price : ValueObject
  {
    public double Value { get; private set; }

    public Price(double price)
    {
      if (price < 1)
      {
        throw new CustomValueObjectException("Price must be greater than zero.");
      }

      Value = price;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
