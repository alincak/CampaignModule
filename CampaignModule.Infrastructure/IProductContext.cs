using CampaignModule.Domain.Entities;

namespace CampaignModule.Infrastructure
{
  public interface IProductContext
  {
    Product Get(string code);
    bool Add(Product entity);
  }
}
