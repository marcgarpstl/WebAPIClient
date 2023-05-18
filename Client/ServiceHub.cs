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
                        ShowAllServices();
                        break;
                    case "update":
                        UpdateService();
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

        private void UpdateService()
        {
            Console.WriteLine("Please provide the Id of the service you want to update");
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
                LoadAllServices();
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
