using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Client
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            ServiceLib start = new ServiceLib();
            start.Run();

           /* while (true)
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
                        Create();
                        break;
                    case "get":
                        //GetService();
                        break;
                    case "update":
                        Update();
                        break;
                    case "delete":
                        Delete();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please write from options above");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }*/
        }
        private static void ReadAllServices()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1");
            HttpResponseMessage response = client.GetAsync(uri).Result;

        }

        private static void Delete()
        {
            throw new NotImplementedException();
        }

        /*static void Update()
        {
            Client client = new Client();

            Console.WriteLine("Which service would you like to update?: ");
            string serviceUpdate = Console.ReadLine();

            bool isAvalible = false;
            Console.WriteLine("New name of the service?: ");
            string name = Console.ReadLine();
            Console.WriteLine("New hourly rate?: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("An updated description?: ");
            string description = Console.ReadLine();
            Console.WriteLine("Is it available right away? y/n");
            string available = Console.ReadLine().ToLower();
            if(available == "y")
            {
                isAvalible = true;
            }
            if(available == "n")
            {
                isAvalible = false;
            }
            Console.WriteLine("Zank you");

            UpdateArgs args =
                new UpdateArgs() { Name = name, Price = price, Description = description, IsAvalible = isAvalible };
            bool success = client.UpdateToDB(args);
            if (success == true)
            {
                Console.WriteLine("Service is updated!");
            }

        }*/

        /*public List<Service> GetService()
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://localhost:7238/api/services1/";
            Uri uri = new Uri(url);

            HttpResponseMessage response = httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Received json: " + json);
                return JsonConvert.DeserializeObject<List<Service>>(json);
            }
            else
            {
                Console.WriteLine("Error. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }

            return new List<Service>();
        }*/

        private static void Create()
        {
            throw new NotImplementedException();
        }


    }
}