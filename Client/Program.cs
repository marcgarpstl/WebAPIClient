using Newtonsoft.Json;
using System.Text;

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
                Console.WriteLine("Read - Show all services");
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

        private static void Delete()
        {
            throw new NotImplementedException();
        }

        private static void Update()
        {
            throw new NotImplementedException();
        }

        private static void Read()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1");
            HttpResponseMessage response = client.GetAsync(uri).Result;

            List<Service> services = JsonConvert.DeserializeObject<List<Service>>(response.ToString());

            foreach (Service service in services)
            {
                Console.WriteLine(service.Name);
            }

            Console.WriteLine("Status code: " + (int)response.StatusCode);
            Console.WriteLine("Means: " + response.StatusCode);

        }

        private static void Create()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7238/api/Services1");

            bool isAvalible = true;

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Description: ");
            string description = Console.ReadLine();

            Service service = new(name, price, description, isAvalible);

            string json = JsonConvert.SerializeObject(service);

            Console.WriteLine("Json sent: " + json);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            Console.WriteLine("Status code: " + (int)response.StatusCode);
            Console.WriteLine("Means: " + response.StatusCode);
        }
    }
}