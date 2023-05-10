using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class HireModel : PageModel
    {
        DataBaseContext dbc;
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }


        public HireModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        [BindProperty]
        public Service service { get; set; }
        [BindProperty]
        public int total { get; set; }

        public void OnGet(int id)
        {
            service = dbc.Services.Find(id);
        }

        public void OnPost(int id,int amount)
        {
            if (!ModelState.IsValid)
            {
                var service = dbc.Services.Find(id);
                amount = int.Parse(Request.Form["total"]);
                var price = dbc.Services.SingleOrDefault(s => s.Id == id).Price;
                total = price * amount;
                service.Id = id;
            }
        }
    }
}
