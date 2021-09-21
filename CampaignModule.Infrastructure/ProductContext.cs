﻿using CampaignModule.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Infrastructure
{
  public class ProductContext : IProductContext
  {
    private static IList<Product> m_list = new List<Product>();

    public bool Add(Product entity)
    {
      if (m_list.Contains(entity))
      {
        return false;
      }

      m_list.Add(entity);

      return true;
    }

    public Product Get(string code)
    {
      return m_list.FirstOrDefault(x => x.Code.Value == code);
    }

  }
}
