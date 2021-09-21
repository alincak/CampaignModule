using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Application.Services
{
  public class OrderService : IOrderService
  {
    private static IList<Order> m_list = new List<Order>();

    public IList<Order> GetOrdersByProductCode(string productCode)
    {
      return m_list.Where(x => x.ProductCode.Value == productCode)?.ToList();
    }

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
