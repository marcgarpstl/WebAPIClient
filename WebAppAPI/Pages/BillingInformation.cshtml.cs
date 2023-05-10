using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class BillingInformationModel : PageModel
    {
        DataBaseContext dbc;

        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; } 
        public string email { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }

        public int total { get; set; }
        public BillingInformationModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        
        [BindProperty]
        public Service service { get; set; }
        [BindProperty]
        public HireModel hire { get; set; }



        public void OnGet(int id, int amount)
        {
            id = int.Parse(Request.Form["id"]);
            service = dbc.Services.Find(id);
            total = amount;
        }

        public ActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                service = dbc.Services.Find(service.Id);
                service.IsAvalible = false;
                dbc.SaveChanges();
                
            }
            return RedirectToPage("/Index");
        }
    }
}
