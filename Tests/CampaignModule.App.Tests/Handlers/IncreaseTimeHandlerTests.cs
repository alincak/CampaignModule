using CampaignModule.App.Handlers;
using CampaignModule.Application.Contracts;
using Moq;
using System;
using Xunit;

namespace CampaignModule.App.Tests.Handlers
{
  public class IncreaseTimeHandlerTests
  {
    private readonly IncreaseTimeHandler _handler;
    private readonly Mock<ICampaignService> _mockCampaignService;
    private readonly Mock<ILocalTimeService> _mockLocalTimeService;

    public IncreaseTimeHandlerTests()
    {
      _mockCampaignService = new Mock<ICampaignService>();
      _mockLocalTimeService = new Mock<ILocalTimeService>();

      _handler = new IncreaseTimeHandler(_mockLocalTimeService.Object, _mockCampaignService.Object);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(3)]
    public void Handler_Munipulation(int hour)
    {
      _mockCampaignService.Setup(x => x.Manipulation(It.IsAny<int>()))
        .Callback(() => _mockLocalTimeService.Object.Update(hour));

      var expectedResult = string.Format($"Time is {hour.ToString().PadLeft(2, '0')}:00");

      _mockLocalTimeService.Setup(x => x.Update(hour)).Returns(hour);
      _mockLocalTimeService.Setup(x => x.Write()).Returns(expectedResult);

      var result = _handler.Handle(new string[] { hour.ToString() });

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

    [Fact]
    public void Handler_ArgsFormatException()
    {
      Assert.Throws<FormatException>(() => _handler.Handle(new string[] { "C1" }));
    }

  }
}
