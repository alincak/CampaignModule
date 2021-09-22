using CampaignModule.App.Handlers;
using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using CampaignModule.Domain.Exceptions;
using Moq;
using System;
using Xunit;

namespace CampaignModule.App.Tests.Handlers
{
  public class CreateProductHandlerTests
  {
    private readonly CreateProductHandler _handler;
    private readonly Mock<IProductService> _mockProductService;

    private readonly Product _product = new Product("P1", 10, 150);
    private readonly string[] _args = new string[] { "P1", "10", "150" };

    public CreateProductHandlerTests()
    {
      _mockProductService = new Mock<IProductService>();

      _handler = new CreateProductHandler(_mockProductService.Object);
    }

    [Fact]
    public void Handler_Created()
    {
      _mockProductService.Setup(x => x.Add(It.IsAny<Product>())).Returns(true);

      var result = _handler.Handle(_args);

      Assert.StartsWith("created - " + _product.ToString(), result);
    }

    [Fact]
    public void Handler_CouldNotCreated()
    {
      _mockProductService.Setup(x => x.Add(It.IsAny<Product>())).Returns(false);

      var result = _handler.Handle(_args);

      Assert.Equal(Strings.Messages.ProductCouldNotCreated, result);
    }

    [Fact]
    public void Handler_ArgsNullReferenceException()
    {
      Assert.Throws<NullReferenceException>(() => _handler.Handle(null));
    }

    [Fact]
    public void Handler_ArgsIndexOutOfRangeException()
    {
      Assert.Throws<IndexOutOfRangeException>(() => _handler.Handle(new string[] { "C1" }));
    }

    [Fact]
    public void Handler_ArgsFormatException()
    {
      Assert.Throws<FormatException>(() => _handler.Handle(new string[] { "P1", "CC" }));
    }

    [Fact]
    public void Handler_CustomValueObjectException()
    {
      _mockProductService.Setup(x => x.Add(It.IsAny<Product>())).Returns(true);

      Assert.Throws<CustomValueObjectException>(() => _handler.Handle(new string[] { "P1", "-1", "150" }));
    }

  }
}
