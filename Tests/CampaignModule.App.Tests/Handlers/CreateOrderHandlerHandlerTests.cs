using CampaignModule.App.Handlers;
using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using Moq;
using System;
using Xunit;

namespace CampaignModule.App.Tests.Handlers
{
  public class CreateOrderHandlerHandlerTests
  {
    private readonly CreateOrderHandler _handler;
    private readonly Mock<IProductService> _mockProductService;
    private readonly Mock<IOrderService> _mockOrderService;

    private readonly Product _product = new Product("P1", 10, 150);
    private readonly string[] _args = new string[] { "P1", "10" };

    public CreateOrderHandlerHandlerTests()
    {
      _mockProductService = new Mock<IProductService>();
      _mockOrderService = new Mock<IOrderService>();

      _handler = new CreateOrderHandler(_mockProductService.Object, _mockOrderService.Object);
    }

    [Fact]
    public void Handler_ProductNotFound()
    {
      Product product = null;
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(product);

      var result = _handler.Handle(_args);

      Assert.Equal(Strings.Messages.ProductNotFound, result);
    }

    [Fact]
    public void Handler_NotEnoughStock()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);

      var result = _handler.Handle(new string[] { "P1", (_product.Stock.Value + 1).ToString() });

      Assert.Equal(Strings.Messages.NotEnoughStock, result);
    }

    [Fact]
    public void Handler_Created()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);
      _mockOrderService.Setup(x => x.Add(It.IsAny<Order>())).Returns(true);

      var result = _handler.Handle(_args);

      var newOrder = new Order(_product.Code.Value, _product.CampaignPrice.Value, double.Parse(_args[1]));

      Assert.StartsWith(newOrder.ToString(), result);
    }

    [Fact]
    public void Handler_CouldNotCreated()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);
      _mockOrderService.Setup(x => x.Add(It.IsAny<Order>())).Returns(false);

      var result = _handler.Handle(_args);

      Assert.Equal(Strings.Messages.OrderCouldNotCreated, result);
    }

    [Fact]
    public void Handler_ArgsNullReferenceException()
    {
      Assert.Throws<NullReferenceException>(() => _handler.Handle(null));
    }

    [Fact]
    public void Handler_ArgsIndexOutOfRangeException()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);

      Assert.Throws<IndexOutOfRangeException>(() => _handler.Handle(new string[] { "C1" }));
    }

    [Fact]
    public void Handler_ArgsFormatException()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);

      Assert.Throws<FormatException>(() => _handler.Handle(new string[] { "P1", "CC" }));
    }

  }
}
