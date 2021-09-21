using CampaignModule.Application.Contracts;
using CampaignModule.Application.Services;

namespace CampaignModule.App.Handlers
{
  public class IncreaseTimeHandler : ICustomHandler
  {
    private readonly ILocalTimeService _localTimeService;
    private readonly ICampaignService _campaignService;

    public IncreaseTimeHandler()
    {
      _localTimeService = new LocalTimeService();
      _campaignService = new CampaignService();
    }

    public string Handle(string[] args)
    {
      _campaignService.Manipulation(int.Parse(args[0]));

      return _localTimeService.Write();
    }

  }
}
