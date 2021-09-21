using CampaignModule.Application.Contracts;
using CampaignModule.Application.Services;
using CampaignModule.Domain.Entities;

namespace CampaignModule.App.Handlers
{
  public class CreateCampaignHandler : ICustomHandler
  {
    private readonly IProductService _productService;
    private readonly ICampaignService _campaignService;

    public CreateCampaignHandler()
    {
      _productService = new ProductService();
      _campaignService = new CampaignService();
    }

    public string Handle(string[] args)
    {
      var product = _productService.Get(args[1]);
      if (product == null)
      {
        return Strings.Messages.ProductNotFound;
      }

      var newCampaign = new Campaign(args[0], product.Code.Value, int.Parse(args[2]), double.Parse(args[3]), int.Parse(args[4]));

      var result = _campaignService.Add(newCampaign);
      if (result)
      {
        return "created" + newCampaign.ToString();
      }
      
      return Strings.Messages.CampaignCouldNotCreated;
    }

  }
}
