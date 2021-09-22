using System;

namespace CampaignModule.Domain.Exceptions
{
  public class CustomValueObjectException : Exception
  {
    public CustomValueObjectException(string message) : base(message)
    {

    }
  }
}
