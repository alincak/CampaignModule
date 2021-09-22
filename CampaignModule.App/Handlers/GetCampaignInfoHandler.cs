using CampaignModule.Application.Contracts;
using CampaignModule.Application.Services;
using System.Linq;

namespace CampaignModule.App.Handlers
{
  public class GetCampaignInfoHandler : ICustomHandler
  {
    private readonly IOrderService _orderService;
    private readonly ICampaignService _campaignService;

    public GetCampaignInfoHandler()
    {
      _orderService = new OrderService();
      _campaignService = new CampaignService();
    }

    public GetCampaignInfoHandler(IOrderService orderService, ICampaignService campaignService)
    {
      _orderService = orderService;
      _campaignService = campaignService;
    }

    public string Handle(string[] args)
    {
      var campaign = _campaignService.Get(args[0]);
      if (campaign == null)
      {
        return Strings.Messages.CampaignNotFound;
      }

      var ordersSummary = GetOrdersSummary(campaign.ProductCode.Value);

      var isActive = campaign.IsActive ? "Active" : "Ended";
      return string.Format($"Campaign {campaign.Name.Value} info; Status {isActive}, Target Sales {campaign.TargetSalesCount.Value}, {ordersSummary}");
    }

    private string GetOrdersSummary(string productCode)
    {
      var orders = _orderService.GetOrdersByProductCode(productCode);
      if (orders == null || !orders.Any())
      {
        return "Total Sales 0, Turnover 0, Average Item Price -";
      }

      var totalSales = orders.Sum(x => x.Quantity.Value);
      var turnover = orders.Select(x => x.Quantity.Value * x.Price.Value).Sum();
      var priceAverage = orders.Average(x => x.Price.Value);

      return string.Format($"Total Sales {totalSales}, Turnover {turnover}, Average Item Price {priceAverage}");
    }

  }
}
