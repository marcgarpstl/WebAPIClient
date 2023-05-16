using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Models
{    
        public class UpdateArgs
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public bool IsAvalible { get; set; }
        }
    
}
