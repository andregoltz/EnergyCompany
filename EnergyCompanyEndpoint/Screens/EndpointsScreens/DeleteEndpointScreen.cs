using EnergyCompany.Domain.Models;
using System;
using System.Linq;

namespace EnergyCompanyEndpoint.Screens.EndpointsScreens
{
    public static class DeleteEndpointScreen
    {
        #region LoadMethod
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete an existing endpoint");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();
            Delete(serialNumber);
            MenuEndpointScreen.Load();

        }
        #endregion

        #region Methods
        private static void Delete(string serialNumber)
        {
            var endpoint = new Endpoint();
            Console.WriteLine();
            var choosenEndpoint = endpoint.ListOneBySerialNumber(serialNumber);
            if (choosenEndpoint.Count() > 0)
            {
                Console.WriteLine("Are you sure that the endpoint should be deleted? (Y / N)");
                var option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "Y":
                        var isDeleted = endpoint.Delete(serialNumber);
                        Console.WriteLine();
                        if (isDeleted)
                        {
                            Console.WriteLine("Endpoint is deleted");
                            Console.WriteLine();
                            Console.WriteLine("Press ANY key to continue;");
                        }
                        else
                        {
                            Console.WriteLine("The endpoint is not found it to be deleted");
                            Console.WriteLine();
                            Console.WriteLine("Press ANY key to continue;");
                        }
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
                        MenuEndpointScreen.Load();
                        break;
                }     
            }
            else
            {
                Console.WriteLine("The endpoint is not found it to be deleted");
                Console.WriteLine();
                Console.WriteLine("Press ANY key to continue;");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
