using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsAvalible { get; set; }
        public Service(string name, int price, string description, bool isAvalible)
        {
            Name = name;
            Price = price;
            Description = description;
            IsAvalible = isAvalible;
        }

        public Service()
        {
        }
    }
}
