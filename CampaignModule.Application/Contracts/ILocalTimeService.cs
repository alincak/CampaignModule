namespace CampaignModule.Application.Contracts
{
  public interface ILocalTimeService
  {
    int Get();
    void Set(int hour);
  }
}
