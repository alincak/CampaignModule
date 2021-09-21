namespace CampaignModule.Application
{
  public class LocalTimeService : ILocalTimeService
  {
    private static int m_localTime = 0;

    public int Get()
    {
      return m_localTime;
    }

    public void Set(int hour)
    {
      m_localTime += hour;
    }
  }
}
