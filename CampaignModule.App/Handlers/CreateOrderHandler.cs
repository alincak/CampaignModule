using CampaignModule.Application.Contracts;
using CampaignModule.Application.Services;
using CampaignModule.Domain.Entities;

namespace CampaignModule.App.Handlers
{
  public class CreateOrderHandler : ICustomHandler
  {
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;

    public CreateOrderHandler()
    {
      _productService = new ProductService();
      _orderService = new OrderService();
    }

    public CreateOrderHandler(IProductService productService, IOrderService orderService)
    {
      _productService = productService;
      _orderService = orderService;
    }

    public string Handle(string[] args)
    {
      var product = _productService.Get(args[0]);
      if (product == null)
      {
        return Strings.Messages.ProductNotFound;
      }

      var quantity = int.Parse(args[1]);
      if (product.Stock.Value < quantity)
      {
        return Strings.Messages.NotEnoughStock;
      }

      var newOrder = new Order(product.Code.Value, product.CampaignPrice.Value, quantity);

      var result = _orderService.Add(newOrder);
      if (result)
      {
        product.ReduceStock(quantity);

        return newOrder.ToString();
      }

      return Strings.Messages.OrderCouldNotCreated;
    }

  }
}
