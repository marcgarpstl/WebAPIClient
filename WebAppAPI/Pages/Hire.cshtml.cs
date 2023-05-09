using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class HireModel : PageModel
    {
        DataBaseContext dbc;
        public int sum;
        public HireModel(DataBaseContext dbc)
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
            return RedirectToPage("/BillingInformation");
        }
    }
}
