using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Application.Services
{
  public class CampaignService : ICampaignService
  {
    private static IList<Campaign> campaigns = new List<Campaign>();

    private readonly ILocalTimeService _localTimeSerivce;
    private readonly IProductService _productService;

    public CampaignService()
    {
      _localTimeSerivce = new LocalTimeService();
      _productService = new ProductService();
    }

    public bool Add(Campaign entity)
    {
      if (campaigns.Contains(entity))
      {
        return false;
      }

      campaigns.Add(entity);

      return true;
    }

    public Campaign Get(string name)
    {
      return campaigns.FirstOrDefault(x => x.Name.Value == name);
    }

    public void Manipulation(int hour)
    {
      _localTimeSerivce.Update(hour);

      if (campaigns != null && campaigns.Any())
      {
        foreach (var campaign in campaigns)
        {
          if (!campaign.IsActive || hour < 1 || campaign.Duration.Value < hour)
          {
            continue;
          }

          var product = _productService.Get(campaign.ProductCode.Value);
          if (product == null)
          {
            continue;
          }

          var limitCalculatedValue = campaign.ProductPrice.Value - (campaign.ProductPrice.Value * campaign.PriceManipulationLimit.Value / 100);
          var rateOfIncrease = 0.5 * 1 / campaign.Duration.Value;
          var decreaseValue = campaign.ProductPrice.Value * rateOfIncrease;
          var priceValue = campaign.ProductPrice.Value - decreaseValue;

          if (limitCalculatedValue <= priceValue)
          {
            campaign.SetProductPrice(priceValue);
            campaign.SetDuration(campaign.Duration.Value - hour);

            product.SetCampaignPrice(priceValue);
          }
          else
          {
            campaign.SetProductPrice(priceValue);
            campaign.EndCampaign();
            
            product.SetCampaignPrice(priceValue);
          }
        }
      }
    }

  }
}
