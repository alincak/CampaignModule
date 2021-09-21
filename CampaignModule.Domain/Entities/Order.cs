using CampaignModule.Domain.Core;
using CampaignModule.Domain.ValueObjects;

namespace CampaignModule.Domain.OrderModels
{
  public class Order : Entity, IAggregateRoot
  {
    public Order(string productCode, double price, double quantity)
    {
      ProductCode = new ProductCode(productCode);
      Price = new Price(price);
      Quantity = new Quantity(quantity);
    }

    public ProductCode ProductCode { get; private set; }
    public Price Price { get; private set; }
    public Quantity Quantity { get; private set; }
  }
}
