using CampaignModule.Domain.Core;
using CampaignModule.Domain.ValueObjects;

namespace CampaignModule.Domain.Entities
{
  public class Campaign : Entity, IAggregateRoot
  {
    public Campaign(string name, string productCode, int duration, double priceManipulationLimit, int targetSalesCount)
    {
      Name = new Name(name);
      ProductCode = new ProductCode(productCode);
      Duration = new Duration(duration);
      PriceManipulationLimit = new PriceManipulationLimit(priceManipulationLimit);
      TargetSalesCount = new TargetSalesCount(targetSalesCount);
      IsActive = true;
    }

    public Name Name { get; private set; }
    public ProductCode ProductCode { get; private set; }
    public Duration Duration { get; private set; }
    public PriceManipulationLimit PriceManipulationLimit { get; private set; }
    public TargetSalesCount TargetSalesCount { get; private set; }
    public bool IsActive { get; private set; }

    public void EndCampaign()
    {
      IsActive = false;
    }
  }
}
