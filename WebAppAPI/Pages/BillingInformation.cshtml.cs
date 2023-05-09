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
        public string firstName;
        public string lastName;
        public string address;
        public string phonenumber;
        public string email;
        public string zipcode;
        public string city;
        public BillingInformationModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        [BindProperty]
        public Service service { get; set; }

        public void OnGet(int id)
        {
            service = dbc.Services.Find(id);
        }

        public ActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                service = dbc.Services.Find(service.Id);
                service.IsAvalible = false;
                dbc.SaveChanges();
            }
            return RedirectToPage("/Index");
        }
    }
}
