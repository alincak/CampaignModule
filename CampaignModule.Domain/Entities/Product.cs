using CampaignModule.Domain.Core;
using CampaignModule.Domain.ValueObjects;

namespace CampaignModule.Domain.Entities
{
  public class Product : Entity, IAggregateRoot
  {
    public Product(string code, double price, double stock)
    {
      Code = new ProductCode(code);
      Price = new Price(price);
      CampaignPrice = Price;
      Stock = new Stock(stock);
    }

    public ProductCode Code { get; set; }
    public Price Price { get; private set; }
    public Price CampaignPrice { get; set; }
    public Stock Stock { get; set; }
  }
}
