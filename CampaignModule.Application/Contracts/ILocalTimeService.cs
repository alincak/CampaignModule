namespace CampaignModule.Application.Contracts
{
  public interface ILocalTimeService
  {
    string Write();
    int Get();
    int Update(int hour);
  }
}
