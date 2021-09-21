using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using System.Collections.Generic;

namespace CampaignModule.Application.Services
{
  public class OrderService : IOrderService
  {
    private static IList<Order> m_list = new List<Order>();

    public bool Add(Order entity)
    {
      if (m_list.Contains(entity))
      {
        return false;
      }

      m_list.Add(entity);

      return true;
    }
  }
}
