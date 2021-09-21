using CampaignModule.App.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.App
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Do you want to continue with temp data? (y/n): ");
      var key = Console.ReadLine();

      if (key == "n")
      {
        Console.WriteLine("exit command: q");

        do
        {
          Console.Write("enter command: ");
          var _command = Console.ReadLine();
          if (_command == "q")
          {
            Environment.Exit(-1);
          }

          HandlerHelper(_command);
        } while (true);
      }
      else
      {
        RunTempInput();
      }
    }

    static void RunTempInput()
    {
      var inputList = GetTempInput();
      foreach (var item in inputList)
      {
        HandlerHelper(item);
      }
    }

    static void HandlerHelper(string command)
    {
      if (string.IsNullOrEmpty(command))
      {
        return;
      }

      try
      {
        var list = command.Split(" ").ToList();
        var method = list.First();
        list.RemoveAt(0);

        var result = "";
        switch (method)
        {
          case "create_product":
            result = new CreateProductHandler().Handle(list.ToArray());
            break;
          case "get_product_info":
            result = new GetProductInfoHandler().Handle(list.ToArray());
            break;
          case "create_order":
            result = new CreateOrderHandler().Handle(list.ToArray());
            break;
          case "create_campaign":
            result = new CreateCampaignHandler().Handle(list.ToArray());
            break;
          case "get_campaign_info":
            result = new GetCampaignInfoHandler().Handle(list.ToArray());
            break;
          case "increase_time":
            result = new IncreaseTimeHandler().Handle(list.ToArray());
            break;
          default:
            break;
        }

        if (!string.IsNullOrEmpty(result))
        {
          Console.WriteLine(result);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    static List<string> GetTempInput()
    {
      return new List<string>
      {
        "create_product P1 100 1000",
        "create_campaign C1 P1 10 20 100" ,
        "create_order P1 3" ,
        "get_product_info P1" ,
        "increase_time 1" ,
        "create_order P1 8" ,
        "get_product_info P1" ,
        "increase_time 1" ,
        "create_order P1 12" ,
        "get_product_info P1" ,
        "increase_time 1" ,
        "create_order P1 7",
        "get_product_info P1",
        "increase_time 2",
        "create_order P1 21",
        "get_product_info P1",
        "increase_time 1",
        "create_order P1 4",
        "get_product_info P1",
        "increase_time 1",
        "create_order P1 3",
        "get_product_info P1",
        "increase_time 2",
        "create_order P1 3",
        "get_product_info P1",
        "increase_time 1",
        "get_campaign_info C1",
      };
    }
  }
}
