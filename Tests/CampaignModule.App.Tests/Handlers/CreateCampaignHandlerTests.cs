using CampaignModule.App.Handlers;
using CampaignModule.Application.Contracts;
using CampaignModule.Domain.Entities;
using CampaignModule.Domain.Exceptions;
using Moq;
using System;
using Xunit;

namespace CampaignModule.App.Tests.Handlers
{
  public class CreateCampaignHandlerTests
  {
    private readonly CreateCampaignHandler _handler;
    private readonly Mock<IProductService> _mockProductService;
    private readonly Mock<ICampaignService> _mockCampaignService;

    private readonly Product _product = new Product("P1", 10, 150);
    private readonly string[] _args = new string[] { "C1", "P1", "10", "20", "150" };

    public CreateCampaignHandlerTests()
    {
      _mockProductService = new Mock<IProductService>();
      _mockCampaignService = new Mock<ICampaignService>();

      _handler = new CreateCampaignHandler(_mockProductService.Object, _mockCampaignService.Object);
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
    public void Handler_Created()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);
      _mockCampaignService.Setup(x => x.Add(It.IsAny<Campaign>())).Returns(true);

      var result = _handler.Handle(_args);

      Assert.StartsWith("created", result);
    }

    [Fact]
    public void Handler_CouldNotCreated()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);
      _mockCampaignService.Setup(x => x.Add(It.IsAny<Campaign>())).Returns(false);

      var result = _handler.Handle(_args);

      Assert.Equal(Strings.Messages.CampaignCouldNotCreated, result);
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
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);

      Assert.Throws<FormatException>(() => _handler.Handle(new string[] { "C1", "P1", "CC" }));
    }

    [Fact]
    public void Handler_CustomValueObjectException()
    {
      _mockProductService.Setup(x => x.Get(It.IsAny<string>())).Returns(_product);
      _mockCampaignService.Setup(x => x.Add(It.IsAny<Campaign>())).Returns(true);

      Assert.Throws<CustomValueObjectException>(() => _handler.Handle(new string[] { "C1", "P1", "-1", "20", "150" }));
    }

  }
}
