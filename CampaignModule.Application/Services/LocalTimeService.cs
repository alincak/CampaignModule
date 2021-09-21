using CampaignModule.Application.Contracts;
using System;

namespace CampaignModule.Application.Services
{
  public class LocalTimeService : ILocalTimeService
  {
    private static DateTime m_localTime = DateTime.UtcNow.Date;

    public string Get()
    {
      return string.Format($"Time is {m_localTime.ToString("HH:mm")}");
    }

    public void Update(int hour)
    {
      m_localTime.AddHours(hour);
    }
  }
}
