using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Application.Services
{
  public class CampaignService : ICampaignService
  {
    private static IList<Campaign> m_list = new List<Campaign>();

    private readonly ILocalTimeService _localTimeSerivce;

    public CampaignService()
    {
      _localTimeSerivce = new LocalTimeService();
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
