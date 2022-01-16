using EnergyCompanyEndpoint.Screens.EndpointsScreens;
using System;

namespace EnergyCompanyEndpoint.Screens.MainMenu
{
    public static class MainMenuScreen
    {
        #region LoadMethod
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Energy Company Application");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Select a menu below:");
            Console.WriteLine();
            Console.WriteLine("1 - Endpoints management");
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
                    MenuEndpointScreen.Load();
                    break;
                case 6:
                    ConfirmExit();
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

        #region Methods
        public static void ConfirmExit()
        {
            Console.WriteLine();
            Console.Write("Do you want to leave the application? (Y / N) ");
            var option = Console.ReadLine().ToUpper();
            switch (option)
            {
                case "Y":
                    Environment.Exit(0);
                    break;
                case "N":
                    Load();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("***** It's not a valid option, please try again. *****");
                    Console.WriteLine("Press ANY key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    ConfirmExit();
                    break;
            }
        }
        #endregion
    }
}
