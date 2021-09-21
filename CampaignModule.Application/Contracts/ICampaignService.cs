using CampaignModule.Domain.Entities;

namespace CampaignModule.Application.Contracts
{
  public interface ICampaignService
  {
    Campaign Get(string name);
    bool Add(Campaign entity);
    void Manipulation(int hour);
  }
}
