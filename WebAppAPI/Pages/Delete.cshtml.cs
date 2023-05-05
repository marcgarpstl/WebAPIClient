using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class DeleteModel : PageModel
    {
        DataBaseContext dbc;
        public DeleteModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        [BindProperty]
        public Service service { get; set; }

        public void OnGet(int id)
        {
            service = dbc.Services.Find(id);
        }
    }
}
