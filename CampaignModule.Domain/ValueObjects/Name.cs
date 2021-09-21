using CampaignModule.Domain.Core;
using System;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class Name : ValueObject
  {
    public string Value { get; private set; }

    public Name(string name)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new Exception("Name is required.");
      }

      Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
