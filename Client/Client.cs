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

        HttpClient http = new();
        string url = "https://localhost:7238/api/Services";

        public List<Service> GetServices()
        {
            Uri uri = new Uri(url);

            HttpResponseMessage response = http.GetAsync(uri).Result;
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Service>>(json);
            }

            Console.WriteLine("Error. " + (int)response.StatusCode + " : " + response.StatusCode);
            return new List<Service>();
        }
        public bool AddService(string name, int price,  string description)
        {
            Service newService = new() {Name = name, Price = price, Description = description, IsAvalible = true };
            
            Uri uri = new Uri(url);

            string jayson = JsonConvert.SerializeObject(newService);
            Console.WriteLine("sending json: " + jayson);

            StringContent stringContent = new StringContent(jayson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = http.PostAsync(uri, stringContent).Result;

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine(name + " was added to the database.");
                return true;
            }

            Console.WriteLine("Error. " + (int)response.StatusCode + " : " + response.StatusCode);
            return false;
        }

        public bool RemoveService(int id)
        {
            Uri uri = new Uri(url + "?id=" + id);

            HttpResponseMessage response = http.DeleteAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Service with id: " + id + " has been removed");
                return true;
            }

            Console.WriteLine("Error. " + (int)response.StatusCode + " : " + response.StatusCode);
            return false;
        }
        public List<Service> GetService()
        {
            Uri uri = new Uri(url);

            HttpResponseMessage response = http.GetAsync(uri).Result;
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
            
            string itemId = args.Id.ToString();
            
            Uri uri = new Uri(url + "?id=" + itemId);

            string json = JsonConvert.SerializeObject(args);
            Console.WriteLine("sending json: " + json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = http.PutAsync(uri, stringContent).Result;

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
