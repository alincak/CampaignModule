namespace CampaignModule.Infrastructure
{
  public class LocalTimeContext : ILocalTimeContext
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
