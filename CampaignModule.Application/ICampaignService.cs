using CampaignModule.Domain.Entities;

namespace CampaignModule.Application
{
  public interface ICampaignService
  {
    Campaign Get(string name);
    bool Add(Campaign entity);
  }
}
