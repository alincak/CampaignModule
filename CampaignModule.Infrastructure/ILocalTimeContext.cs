namespace CampaignModule.Infrastructure
{
  public interface ILocalTimeContext
  {
    int Get();
    void Set(int hour);
  }
}
