using CampaignModule.Domain.Core;
using CampaignModule.Domain.Exceptions;
using System.Collections.Generic;

namespace CampaignModule.Domain.ValueObjects
{
  public class Duration : ValueObject
  {
    public int Value { get; private set; }

    public Duration(int duration)
    {
      if (duration < 1)
      {
        throw new CustomValueObjectException("Duration must be greater than zero.");
      }

      Value = duration;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
