using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Service
    {
        List<Service> services;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsAvalible { get; set; }


        public void LoadService()
        {
            Console.WriteLine("Id: " + Id + "\nService: " + Name + " Price: " + Price + "\nDescription: " + Description + "\nAvailable: " + IsAvalible);

        }
    }
}
