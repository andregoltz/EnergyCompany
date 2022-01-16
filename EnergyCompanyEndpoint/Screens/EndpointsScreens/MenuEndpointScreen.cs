using EnergyCompanyEndpoint.Screens.MainMenu;
using System;

namespace EnergyCompanyEndpoint.Screens.EndpointsScreens
{
    public static class MenuEndpointScreen
    {
        #region LoadMethod
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Endpoints Management");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Select a menu below:");
            Console.WriteLine();
            Console.WriteLine("1 - Insert a new endpoint");
            Console.WriteLine("2 - Edit an existing endpoint");
            Console.WriteLine("3 - Delete an existing endpoint");
            Console.WriteLine("4 - List all endpoints");
            Console.WriteLine("5 - Find a endpoint by " + '\u0022' + "Endpoint Serial Number" + '\u0022');
            Console.WriteLine("6 - Exit");
            Console.WriteLine();
            Console.Write("Option: ");

            short option = 0;
            try
            {
                option = short.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("It's not a valid option, please try again!");
                Console.WriteLine("Press ANY key to continue");
                Console.ReadKey();
                Load();
            }

            switch (option)
            {
                case 1:
                    CreateEndpointScreen.Load();
                    break;
                case 2:
                    UpdateEndpointScreen.Load();
                    break;
                case 3:
                    DeleteEndpointScreen.Load();
                    break;
                case 4:
                    ListAllEndpointScreen.Load();
                    break;
                case 5:
                    ListOneEndpointScreen.Load();
                    break;
                case 6:
                    MainMenuScreen.Load();
                    break;
                default:
                    Console.WriteLine("It's not a valid option, please try again");
                    Console.WriteLine("Press ANY key to continue");
                    Console.ReadKey();
                    Load();
                    break;
            }
        }
        #endregion
    }
}
