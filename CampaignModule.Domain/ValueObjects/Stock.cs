using CampaignModule.Domain.Core;
using CampaignModule.Domain.Exceptions;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class Stock : ValueObject
  {
    public int Value { get; private set; }

    public Stock(int stock)
    {
      if (stock < 1)
      {
        throw new CustomValueObjectException("Stock must be greater than zero.");
      }

      Value = stock;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
