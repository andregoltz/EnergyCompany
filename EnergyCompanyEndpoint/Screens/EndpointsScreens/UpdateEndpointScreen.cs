using EnergyCompany.Domain.Enums;
using EnergyCompany.Domain.Models;
using System;
using System.ComponentModel;
using System.Linq;

namespace EnergyCompanyEndpoint.Screens.EndpointsScreens
{
    public static class UpdateEndpointScreen
    {
        #region LoadMethod
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Edit an existing endpoint");
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();
            FindEndpoint(serialNumber);

            Console.WriteLine();
            Console.WriteLine("You only have access to update the switch state.");
            Console.WriteLine();
            Console.WriteLine("Please enter one of the switch state below.");
            var listEnumsSwitchState = Enum.GetValues(typeof(ESwitchState)).Cast<ESwitchState>();
            foreach (var item in listEnumsSwitchState)
                Console.WriteLine(((int)item) + " - " + item);

            Console.WriteLine();
            Console.Write("Switch State: ");
            var switchState = int.Parse(Console.ReadLine());
            var findEnumSwitchState = Enum.IsDefined(typeof(ESwitchState), switchState);
            ValidateEnum(findEnumSwitchState);

            Update(serialNumber, switchState);

            Console.ReadKey();
            MenuEndpointScreen.Load();
        }
        #endregion

        #region Methods
        private static void FindEndpoint(string serialNumber)
        {
            var endpoint = new Endpoint();
            var choosenEndpoint = endpoint.ListOneBySerialNumber(serialNumber);
            if (choosenEndpoint.Count() > 0)
            {
                foreach (var item in choosenEndpoint)
                {
                    Console.WriteLine();
                    Console.WriteLine("Endpoint was found it");
                    Console.WriteLine();
                    Console.WriteLine($"Serial Number: { item.EndpointSerialNumber }");
                    Console.WriteLine($"Meter Model Id: { item.MeterModelId + " - " + Enum.Parse(typeof(EMeterModelId), item.MeterModelId.ToString()) }");
                    Console.WriteLine($"Meter Number: {item.MeterNumber}");
                    Console.WriteLine($"Meter Firmware Version: {item.MeterFirmwareVersion}");
                    Console.WriteLine($"Switch State: { item.SwitchState + " - " + Enum.Parse(typeof(ESwitchState), item.SwitchState.ToString()) }");
                    Console.WriteLine("---------------------------");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("This endpoint is not registered");
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
        private static void ValidateEnum(bool findEnum)
        {
            try
            {
                if (!findEnum)
                    throw new InvalidEnumArgumentException();
            }
            catch (InvalidEnumArgumentException)
            {
                Console.WriteLine("It's not a valid value, please press ANY key to return to Menu");
                Console.ReadKey();
                Load();
            }
        }
        private static void Update(string serialNumber, int switchstate)
        {
            var endpoint = new Endpoint();
            var isUpdated = endpoint.Update(serialNumber, switchstate);
            if (isUpdated)
            {
                Console.WriteLine("Endpoint updated");
                Console.WriteLine();
                Console.WriteLine("Press ANY key to continue;");
            }
            else
            {
                Console.WriteLine("The endpoint is not found it to be updated");
                Console.WriteLine();
                Console.WriteLine("Press ANY key to continue;");
            }
        }
        #endregion
    }
}
