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
      var newHour = _localTimeSerivce.Update(hour);

      if (campaigns != null && campaigns.Any())
      {
        foreach (var campaign in campaigns)
        {
          if (!campaign.IsActive || newHour < 1 || campaign.Duration.Value < hour)
          {
            continue;
          }

          var product = _productService.Get(campaign.ProductCode.Value);
          if (product == null)
          {
            continue;
          }

          var limit = campaign.PriceManipulationLimit.Value;

          var limitCalculatedValue = product.Price.Value - (product.Price.Value * limit / 100);
          var rateOfIncrease = limit / 100 / campaign.Duration.Value;
          var decreaseValue = product.Price.Value * rateOfIncrease;
          var priceValue = product.CampaignPrice.Value - decreaseValue;

          if (limitCalculatedValue <= priceValue)
          {
            product.SetCampaignPrice(priceValue);
          }
          else
          {
            campaign.EndCampaign();

            product.SetCampaignPrice(product.Price.Value);
          }
        }
      }
    }

  }
}