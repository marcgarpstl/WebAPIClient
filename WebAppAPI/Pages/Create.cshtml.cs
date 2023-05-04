using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class CreateModel : PageModel
    {
        DataBaseContext dbc;

        public CreateModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        [BindProperty]
        public Service service { get; set; }

        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                dbc.Services.Add(service);
                dbc.SaveChanges();
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
