using EnergyCompany.Domain.Enums;
using EnergyCompany.Domain.Models;
using System;
using System.ComponentModel;
using System.Linq;

namespace EnergyCompanyEndpoint.Screens.EndpointsScreens
{
    public static class CreateEndpointScreen
    {
        #region LoadMethod
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Create a new endpoint");
            Console.WriteLine("---------------------------");
            Endpoint endpoint = new Endpoint();

            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();
            ValidateNullorEmptyField(serialNumber);
            var validSerialNumber = endpoint.EndpointAlreadyExists(serialNumber);
            if (!validSerialNumber)
            {
                Console.WriteLine();
                Console.WriteLine("There is already an endpoint registered with this Serial Number " + '\u0022' + serialNumber + '\u0022');
                Console.WriteLine("Press ANY key to continue");
                Console.ReadKey();
                Load();

            }
            Console.WriteLine();

            #region MeterModelId
            Console.WriteLine("Please enter one of the meter models below");
            var listEnumsMeterModel = Enum.GetValues(typeof(EMeterModelId)).Cast<EMeterModelId>();
            foreach (var item in listEnumsMeterModel)
                Console.WriteLine(((int)item) + " - " + item);

            Console.Write("Meter Model: ");
            var meterModel = int.Parse(Console.ReadLine());
            var findEnumMeterModel = Enum.IsDefined(typeof(EMeterModelId), meterModel);
            ValidateEnum(findEnumMeterModel);
            Console.WriteLine();
            #endregion

            #region MeterNumber
            Console.Write("Meter Number: ");
            var meterNumber = 0;
            try
            {
                meterNumber = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("It's not a valid value, the input must be only numbers!");
                Console.WriteLine("Press ANY key to continue");
                Console.ReadKey();
                Load();
            }
            #endregion

            Console.Write("Meter Firmware Version: ");
            var meterFirmware = Console.ReadLine();
            ValidateNullorEmptyField(serialNumber);
            Console.WriteLine();

            #region SwitchState
            Console.WriteLine("Please enter one of the switch states below");
            var listEnumsSwitchState = Enum.GetValues(typeof(ESwitchState)).Cast<ESwitchState>();
            foreach (var item in listEnumsSwitchState)
                Console.WriteLine(((int)item) + " - " + item);

            Console.Write("Switch State: ");
            var switchState = int.Parse(Console.ReadLine());
            var findEnumSwitchState = Enum.IsDefined(typeof(ESwitchState), switchState);
            ValidateEnum(findEnumSwitchState);
            #endregion

            try
            {
                Create(new Endpoint
                {
                    EndpointSerialNumber = serialNumber,
                    MeterModelId = meterModel,
                    MeterNumber = meterNumber,
                    MeterFirmwareVersion = meterFirmware,
                    SwitchState = switchState,
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ops! Something is not right, please try again");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                MenuEndpointScreen.Load();
            }
            MenuEndpointScreen.Load();
        }
        #endregion

        #region Methods
        private static void Create(Endpoint endpoint)
        {
            var insert = endpoint.Save(endpoint);
            if (insert)
            {
                Console.WriteLine();
                Console.WriteLine("Endpoint registered");
                Console.WriteLine("Please press ANY key to continue");
                Console.ReadKey();
            }
            else
            {
                throw new Exception("All fields must be filled!");
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
                MenuEndpointScreen.Load();
            }
        }
        private static void ValidateNullorEmptyField(string field)
        {
            try
            {
                if (string.IsNullOrEmpty(field))
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("The field must contain a value, please press ANY key to return to Menu");
                Console.ReadKey();
                MenuEndpointScreen.Load();
            }
        }
        #endregion
    }
}
