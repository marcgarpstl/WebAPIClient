using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.DatabaseContext;
using WebAppAPI.Models;

namespace WebAppAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    DataBaseContext dbc;
    public ServicesController(DataBaseContext dbc)
    {
        this.dbc = dbc;
    }

    [HttpGet]
    public List<Service> GetObjects()
    {
        return dbc.Services.ToList();
    }
}
