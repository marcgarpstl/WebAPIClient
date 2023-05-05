using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            services = dbc.Services.ToList();
        }
        public ActionResult OnPostDelete(int id)
        {
            Service serviceToDelete = dbc.Services.SingleOrDefault(s => s.Id == id);
            dbc.Services.Remove(serviceToDelete);
            dbc.SaveChanges();
            return RedirectToPage("/Index");

        }
    }
}