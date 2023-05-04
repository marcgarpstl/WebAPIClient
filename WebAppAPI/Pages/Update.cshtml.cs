using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Pages
{
    public class UpdateModel : PageModel
    {
        DataBaseContext dbc;

        public UpdateModel(DataBaseContext dbc)
        {
            this.dbc = dbc;
        }
        [BindProperty]
        public Service service { get; set; }

        public void OnGet(int Id)
        {
            service = dbc.Services.Find(Id);
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Service serviceReg = dbc.Services.Find(service.Id);
                serviceReg.Name = service.Name;
                serviceReg.Price = service.Price;
                serviceReg.Description = service.Description;
                serviceReg.IsAvalible = service.IsAvalible;

                dbc.SaveChanges();
            }
        }
    }
}
