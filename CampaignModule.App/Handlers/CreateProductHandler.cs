using CampaignModule.Application.Contracts;
using CampaignModule.Application.Services;
using CampaignModule.Domain.Entities;

namespace CampaignModule.App.Handlers
{
  public class CreateProductHandler : ICustomHandler
  {
    private readonly IProductService _productService;

    public CreateProductHandler()
    {
      _productService = new ProductService();
    }

    public string Handle(string[] args)
    {
      var newProduct = new Product(args[0], double.Parse(args[1]), int.Parse(args[2]));

      var result = _productService.Add(newProduct);
      if (result)
      {
        return "created - " + newProduct.ToString();
      }

      return Strings.Messages.ProductCouldNotCreated;
    }

  }
}
