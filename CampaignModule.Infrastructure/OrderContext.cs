﻿using CampaignModule.Domain.Entities;
using System.Collections.Generic;

namespace CampaignModule.Infrastructure
{
  public class OrderContext : IOrderContext
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
