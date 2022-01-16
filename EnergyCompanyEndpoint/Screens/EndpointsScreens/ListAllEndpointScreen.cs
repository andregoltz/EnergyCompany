using EnergyCompany.Domain.Enums;
using EnergyCompany.Domain.Models;
using System;

namespace EnergyCompanyEndpoint.Screens.EndpointsScreens
{
    public static class ListAllEndpointScreen
    {
        #region LoadMethod
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List all endpoints");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            ListAll();
            Console.ReadKey();
            MenuEndpointScreen.Load();
        }
        #endregion

        #region Methods
        private static void ListAll()
        {
            var endpoint = new Endpoint();
            var endpoints = endpoint.ListAll();
            if (endpoints.Count > 0)
            {

                foreach (var item in endpoints)
                {
                    Console.WriteLine($"Serial Number: { item.EndpointSerialNumber }");
                    Console.WriteLine($"Meter Model Id: { item.MeterModelId + " - " + Enum.Parse(typeof(EMeterModelId), item.MeterModelId.ToString()) }");
                    Console.WriteLine($"Meter Number: {item.MeterNumber}");
                    Console.WriteLine($"Meter Firmware Version: {item.MeterFirmwareVersion}");
                    Console.WriteLine($"Switch State: { item.SwitchState + " - " + Enum.Parse(typeof(ESwitchState), item.SwitchState.ToString()) }");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine();
                }
                    Console.WriteLine("Press ANY key to continue;");
            }
            else
            {
                Console.WriteLine("There are no endpoints registered");
                Console.WriteLine("Do you want to register a endpoint? (Y / N)");
                var option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "Y":
                        CreateEndpointScreen.Load();
                        break;
                    case "N":
                        MenuEndpointScreen.Load();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("***** It's not a valid option, please try again. *****");
                        Console.WriteLine("Press ANY key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                        break;
                }

            }
        }
        #endregion
    }
}
