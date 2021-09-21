using CampaignModule.Domain.Entities;
using System.Collections.Generic;

namespace CampaignModule.Application.Contracts
{
  public interface IOrderService
  {
    IList<Order> GetOrdersByProductCode(string productCode);
    bool Add(Order entity);
  }
}
