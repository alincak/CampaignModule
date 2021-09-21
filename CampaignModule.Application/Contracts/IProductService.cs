using CampaignModule.Domain.Entities;

namespace CampaignModule.Application.Contracts
{
  public interface IProductService
  {
    Product Get(string code);
    bool Add(Product entity);
  }
}
