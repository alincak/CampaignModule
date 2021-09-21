using CampaignModule.Domain.Entities;

namespace CampaignModule.Application
{
  public interface IProductService
  {
    Product Get(string code);
    bool Add(Product entity);
  }
}
