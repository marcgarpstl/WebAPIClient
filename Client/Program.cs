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
        }

    }
}