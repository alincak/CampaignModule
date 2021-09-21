using CampaignModule.Application.Contracts;

namespace CampaignModule.Application.Services
{
  public class LocalTimeService : ILocalTimeService
  {
    private static int m_localTime = 0;

    public string Write()
    {
      return string.Format($"Time is {m_localTime.ToString().PadLeft(2, '0')}:00");
    }

    public int Get()
    {
      return m_localTime;
    }

    public int Update(int hour)
    {
      m_localTime += hour;

      return m_localTime;
    }
  }
}
