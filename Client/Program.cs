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
            ServiceHub hub = new ServiceHub();
            hub.Run();
        }
    }
}