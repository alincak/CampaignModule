using CampaignModule.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Infrastructure
{
  public class CampaignContext : ICampaignContext
  {
    private static IList<Campaign> m_list = new List<Campaign>();

    private readonly ILocalTimeContext _localTimeContext;

    public CampaignContext()
    {
      _localTimeContext = new LocalTimeContext();
    }

    public bool Add(Campaign entity)
    {
      if (m_list.Contains(entity))
      {
        return false;
      }

      m_list.Add(entity);

      return true;
    }

    public Campaign Get(string name)
    {
      return m_list.FirstOrDefault(x => x.Name.Value == name);
    }
  }
}
