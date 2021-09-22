using CampaignModule.App.Handlers;
using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using Moq;
using System;
using Xunit;

namespace CampaignModule.App.Tests.Handlers
{
  public class GetProductInfoHandlerTests
  {
    private readonly GetProductInfoHandler _handler;
    private readonly Mock<IProductService> _mockProductService;

    private readonly Product _product = new Product("P1", 10, 150);
    private readonly string[] _args = new string[] { "P1" };

    public GetProductInfoHandlerTests()
    {
      _mockProductService = new Mock<IProductService>();

      _handler = new GetProductInfoHandler(_mockProductService.Object);
    }

    [Fact]
    public void Handler_Get()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);

      var result = _handler.Handle(_args);

      Assert.StartsWith(_product.ToString(), result);
    }

    [Fact]
    public void Handler_NotFound()
    {
      Product product = null;
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(product);

      var result = _handler.Handle(_args);

      Assert.Equal(Strings.Messages.ProductNotFound, result);
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
