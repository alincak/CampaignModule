using CampaignModule.Domain.Core;
using CampaignModule.Domain.ValueObjects;

namespace CampaignModule.Domain.Entities
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

    public override string ToString()
    {
      return string.Format($"Order created; product {ProductCode.Value}, quantity {Quantity.Value}");
    }

  }
}
