using CampaignModule.Domain.Entities;

namespace CampaignModule.Infrastructure
{
  public interface IOrderContext
  {
    bool Add(Order entity);
  }
}
