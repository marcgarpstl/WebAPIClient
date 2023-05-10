using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class HireModel : PageModel
    {
        DataBaseContext dbc;
        

        public HireModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        [BindProperty]
        public Service service { get; set; }
        [BindProperty]
        public int amount { get; set; }

        public void OnGet(int id)
        {
            service = dbc.Services.Find(id);
        }

        public ActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                var service = dbc.Services.Find(id);
                var amount = int.Parse(Request.Form["amount"]);
                var price = dbc.Services.SingleOrDefault(s => s.Id == id).Price;
                var total = price * amount;
                amount = total;

                return RedirectToPage("/BillingInformation");
            }
            return Page();
        }
    }
}
