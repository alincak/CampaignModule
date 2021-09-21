using CampaignModule.Domain.Entities;

namespace CampaignModule.Application
{
  public interface IOrderService
  {
    bool Add(Order entity);
  }
}
