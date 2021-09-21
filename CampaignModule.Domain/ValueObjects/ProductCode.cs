using CampaignModule.Domain.Core;
using System;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class ProductCode : ValueObject
  {
    public string Value { get; private set; }

    public ProductCode(string code)
    {
      if (string.IsNullOrEmpty(code))
      {
        throw new Exception("Product code is required.");
      }

      Value = code;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
