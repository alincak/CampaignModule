using CampaignModule.App.Handlers;
using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CampaignModule.App.Tests.Handlers
{
  public class GetCampaignInfoHandlerTests
  {
    private readonly GetCampaignInfoHandler _handler;
    private readonly Mock<IOrderService> _mockOrderService;
    private readonly Mock<ICampaignService> _mockCampaignService;

    private readonly Campaign _campaign = new Campaign("C1", "P1", 10, 20, 15);
    private readonly string[] _args = new string[] { "C1" };

    public GetCampaignInfoHandlerTests()
    {
      _mockOrderService = new Mock<IOrderService>();
      _mockCampaignService = new Mock<ICampaignService>();

      _handler = new GetCampaignInfoHandler(_mockOrderService.Object, _mockCampaignService.Object);
    }

    [Fact]
    public void Handler_Created()
    {
      Campaign campaign = null;
      _mockCampaignService.Setup(x => x.Get(It.IsAny<string>())).Returns(campaign);

      var result = _handler.Handle(_args);

      Assert.StartsWith(Strings.Messages.CampaignNotFound, result);
    }

    [Fact]
    public void Handler_OrdersIsNull()
    {
      _mockCampaignService.Setup(x => x.Get(It.IsAny<string>())).Returns(_campaign);

      IList<Order> orders = null;
      _mockOrderService.Setup(x => x.GetOrdersByProductCode(It.IsAny<string>())).Returns(orders);

      var result = _handler.Handle(_args);

      var isActive = _campaign.IsActive ? "Active" : "Ended";
      var expectedResult = string.Format($"Campaign {_campaign.Name.Value} info; Status {isActive}, Target Sales {_campaign.TargetSalesCount.Value}, Total Sales 0, Turnover 0, Average Item Price -");

      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Handler_OrdersIsAny()
    {
      var orders = new List<Order>
      {
        new Order("P1", 10, 2),
        new Order("P1", 10, 2),
        new Order("P1", 10, 2)
      };

      _mockCampaignService.Setup(x => x.Get(It.IsAny<string>())).Returns(_campaign);
      _mockOrderService.Setup(x => x.GetOrdersByProductCode(It.IsAny<string>())).Returns(orders);

      var result = _handler.Handle(_args);

      var totalSales = orders.Sum(x => x.Quantity.Value);
      var turnover = orders.Select(x => x.Quantity.Value * x.Price.Value).Sum();
      var priceAverage = orders.Average(x => x.Price.Value);
      var ordersSummary = string.Format($"Total Sales {totalSales}, Turnover {turnover}, Average Item Price {priceAverage}");

      var isActive = _campaign.IsActive ? "Active" : "Ended";
      var expectedResult = string.Format($"Campaign {_campaign.Name.Value} info; Status {isActive}, Target Sales {_campaign.TargetSalesCount.Value}, {ordersSummary}");

      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Handler_ArgsNullReferenceException()
    {
      Assert.Throws<NullReferenceException>(() => _handler.Handle(null));
    }

    [Fact]
    public void Handler_ArgsIndexOutOfRangeException()
    {
      Assert.Throws<IndexOutOfRangeException>(() => _handler.Handle(new string[] { }));
    }

  }
}
