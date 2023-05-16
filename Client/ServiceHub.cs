using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ServiceHub
    {
        List<Service> services;

        Client client = new();

        public ServiceHub()
        {
            ShowAllServices();
        }

        public void ShowAllServices()
        {
            services = client.GetServices();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Create - Create a new service");
                Console.WriteLine("Read - Show all services");
                Console.WriteLine("Update - Update existing service");
                Console.WriteLine("Delete - Delete service");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "create":
                        NewService();
                        break;
                    case "read":
                        LoadAllServices();
                        break;
                    case "update":
                        //Update();
                        break;
                    case "delete":
                        DeleteService();
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

        private void DeleteService()
        {
            Console.WriteLine("Please provide the Id of the service you want to remove");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine("Only Id is accepted");
                return;
            }
            bool success = client.RemoveService(id);
            if(success)
            {
                services.Remove(services.SingleOrDefault(services => services.Id == id));
            }
        }

        private void NewService()
        {

            Console.Write("Please provide a name for the service: ");
            string name = Console.ReadLine();
            Console.Write("Please provide a price for the service: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Describe the service you would like to create: ");
            string description = Console.ReadLine();

            bool success = client.AddService(name, price, description); 
            if(success)
            {
                ShowAllServices();
            }

        }

        private void LoadAllServices()
        {
            foreach (Service service in services)
            {
                service.LoadService();
            }
        }
    }
}
