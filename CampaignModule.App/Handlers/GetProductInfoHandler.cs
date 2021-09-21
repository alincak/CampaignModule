using CampaignModule.Application.Contracts;
using CampaignModule.Application.Services;

namespace CampaignModule.App.Handlers
{
  public class GetProductInfoHandler : ICustomHandler
  {
    private readonly IProductService _productService;

    public GetProductInfoHandler()
    {
      _productService = new ProductService();
    }

    public string Handle(string[] args)
    {
      var product = _productService.Get(args[0]);
      if (product == null)
      {
        return Strings.Messages.ProductNotFound;
      }

      return product.ToString();
    }

  }
}
