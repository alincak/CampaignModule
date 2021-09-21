using CampaignModule.Domain.Entities;

namespace CampaignModule.Application.Contracts
{
  public interface IOrderService
  {
    bool Add(Order entity);
  }
}
