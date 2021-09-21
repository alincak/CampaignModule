using CampaignModule.Domain.Core;
using CampaignModule.Domain.ValueObjects;

namespace CampaignModule.Domain.Entities
{
  public class Campaign : Entity, IAggregateRoot
  {
    public Campaign(string name, string productCode, double productPrice, int duration, double priceManipulationLimit, int targetSalesCount)
    {
      Name = new Name(name);
      ProductCode = new ProductCode(productCode);
      ProductPrice = new Price(productPrice);
      Duration = new Duration(duration);
      PriceManipulationLimit = new PriceManipulationLimit(priceManipulationLimit);
      TargetSalesCount = new TargetSalesCount(targetSalesCount);
      IsActive = true;
    }

    public Name Name { get; set; }
    public ProductCode ProductCode { get; set; }
    public Price ProductPrice { get; set; }
    public Duration Duration { get; set; }
    public PriceManipulationLimit PriceManipulationLimit { get; set; }
    public TargetSalesCount TargetSalesCount { get; set; }
    public bool IsActive { get; private set; }

    public void EndCampaign()
    {
      IsActive = false;
    }
  }
}
