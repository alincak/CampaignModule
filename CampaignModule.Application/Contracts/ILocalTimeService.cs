namespace CampaignModule.Application.Contracts
{
  public interface ILocalTimeService
  {
    string Get();
    void Update(int hour);
  }
}
