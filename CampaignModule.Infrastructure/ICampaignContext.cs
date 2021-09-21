using CampaignModule.Domain.Entities;

namespace CampaignModule.Infrastructure
{
  public interface ICampaignContext
  {
    Campaign Get(string name);
    bool Add(Campaign entity);
  }
}
