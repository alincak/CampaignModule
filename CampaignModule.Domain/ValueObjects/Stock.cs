using CampaignModule.Domain.Core;
using System;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class Stock : ValueObject
  {
    public double Value { get; private set; }

    public Stock(double stock)
    {
      if (stock < 1)
      {
        throw new Exception("Stock must be greater than zero.");
      }

      Value = stock;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
