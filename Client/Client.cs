using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        HttpClient httpClient = new HttpClient();
        string url = "https://localhost:7238/api/Services1";
        
        public List<Service> GetService()
        {
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
        }

        public bool UpdateToDB(UpdateArgs args)
        {
            HttpClient httpClient = new HttpClient();
            string itemId = args.Id.ToString();
            string url = "https://localhost:7238/api/services";
            Uri uri = new Uri(url + "?id=" + itemId);

            string json = JsonConvert.SerializeObject(args);
            Console.WriteLine("sending json: " + json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(args.Name + " successfully changed price to " + args.Price);
                return true;
            }
            Console.WriteLine("Error. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            return false;
        }
    }
}
