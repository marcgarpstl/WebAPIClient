using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Create - Create a new service");
                Console.WriteLine("Read - Show specific");
                Console.WriteLine("All - See all");
                Console.WriteLine("Update - Update existing service");
                Console.WriteLine("Delete - Delete service");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "create":
                        Create();
                        break;
                    case "read":
                        Read();
                        break;
                    case "all":
                        ReadAllServices();
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
            }
        }

        private static void ReadAllServices()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1");
            HttpResponseMessage response = client.GetAsync(uri).Result;
            
        }

        private static void Delete()
        {
            Console.WriteLine("Please write the name of the service you want to delete.");
            int id = int.Parse(Console.ReadLine());

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1/" + id);

            HttpResponseMessage response = client.DeleteAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Service with id: " + id + ", has successfully been deleted.");
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }

        private static void Update()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Update");

            bool isAvalible;

            Console.Write("Please provide the name of the service you would like to update: ");
            string name = Console.ReadLine();
            Console.Write("Whats the new price for the service: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Whats the new decription for the service?: ");
            string description = Console.ReadLine();
            Console.WriteLine("Is the services available? Yes / No");
            string avalible = Console.ReadLine().ToLower();
            if(avalible == "yes")
            {
                isAvalible = true;
            }
            else
            {
                isAvalible = false;
            }

            Service service = new Service() { Name = name, Price = price, Description = description, IsAvalible = isAvalible };

            string json = JsonSerializer.Serialize(service);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(uri, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The service price has been updated to: " + service.Price + " and Description to " + service.Description + "!");
            }
            else
            {
                Console.WriteLine("Update of service failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }

        private static void Read()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1");
            HttpResponseMessage response = client.GetAsync(uri).Result;

            Console.WriteLine("Please write the Id of the service you want.");
            int id = int.Parse(Console.ReadLine());


            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1/" + id);

            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
                Service service = JsonSerializer.Deserialize<Service>(json);
                Console.WriteLine("Service " + service.Name "is ready");
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }

            Console.WriteLine("Status code: " + (int)response.StatusCode);
            Console.WriteLine("Means: " + response.StatusCode);

        }

        private static void Create()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1");

            bool isAvalible = true;

            Console.Write("Please provide a name for the service: ");
            string name = Console.ReadLine();
            Console.Write("Please provide a price for the service: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Describe the service you would like to create: ");
            string description = Console.ReadLine();

            Service service = new(name, price, description, isAvalible);

            string json = JsonConvert.SerializeObject(service);

            Console.WriteLine("Json sent: " + json);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The service with name:" + service.Name + " Price: " + service.Price + " And Description " + service.Description + "has been successfully registered!");
            }
            else
            {
                Console.WriteLine("Creation of service failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }
    }
}