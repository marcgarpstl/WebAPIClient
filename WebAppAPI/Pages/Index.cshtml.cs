using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class IndexModel : PageModel
    {
        DataBaseContext dbc { get; set; }

        public IndexModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }

        public List<Service> services { get; set; }

        public void OnGet()
        {
            if (services.IsNullOrEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }
            services = dbc.Services.ToList();
        }
    }
}