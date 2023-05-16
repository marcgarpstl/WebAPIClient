using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Client
{
    public class ServiceLib
    {
        public List<Service> services;
        Client client = new Client();

        public ServiceLib()
        {
            LoadServices();
        }
        public void LoadServices()
        {
            services = client.GetService();
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Create - Create a new service");
                Console.WriteLine("Get - Show all services");
                Console.WriteLine("Update - Update existing service");
                Console.WriteLine("Delete - Delete service");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "create":
                        //Create();
                        break;
                    case "get":
                        PrintServices();
                        break;
                    case "update":
                        Update();
                        break;
                    case "delete":
                        //Delete();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please write from options above");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
        static void Update()
        {
            Client client = new Client();
            List<Service> services = client.GetService();
            
            Console.WriteLine("Please provide the Id of the service you want to remove");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Only Id is accepted");
                return;
            }
            bool isAvalible = true;
            Console.WriteLine("New name of the service?: ");
            string name = Console.ReadLine();
            Console.WriteLine("New hourly rate?: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("An updated description?: ");
            string description = Console.ReadLine();
            Console.WriteLine("Is it available right away? y/n");
            string available = Console.ReadLine().ToLower();
            if (available == "y")
            {
                isAvalible = true;
            }
            if (available == "n")
            {
                isAvalible = false;
            }
            Console.WriteLine("Zank you");

            UpdateArgs args =
                new UpdateArgs() { Id = id, Name = name, Price = price, Description = description, IsAvalible = isAvalible };
            bool success = client.UpdateToDB(args);
            if (success)
            {
                services.Add(services.SingleOrDefault(services => services.Id == id));
            }

        }
        private void PrintServices()
        {
            foreach (Service service in services)
            {
                service.PrintService();
            }
        }
    }
}
