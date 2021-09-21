using CampaignModule.Domain.Core;
using CampaignModule.Domain.ValueObjects;

namespace CampaignModule.Domain.Entities
{
  public class Product : Entity, IAggregateRoot
  {
    public Product(string code, double price, int stock)
    {
      Code = new ProductCode(code);
      Price = new Price(price);
      CampaignPrice = Price;
      Stock = new Stock(stock);
    }

    public ProductCode Code { get; private set; }
    public Price Price { get; private set; }
    public Price CampaignPrice { get; private set; }
    public Stock Stock { get; private set; }

    public void SetCampaignPrice(double price)
    {
      CampaignPrice = new Price(price);
    }

    public void ReduceStock(int quantity)
    {
      Stock = new Stock(Stock.Value - quantity);
    }

    public override string ToString()
    {
      return string.Format($"Product {Code.Value} info; price {CampaignPrice.Value}, stock {Stock.Value}");
    }

  }
}
