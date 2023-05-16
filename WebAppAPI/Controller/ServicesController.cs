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
    // GET: api/Services
    [HttpGet]
    public ActionResult<List<Service>> GetServices()
    {
        return dbc.Services.ToList();
    }


    [HttpPost]
    public ActionResult AddService([FromBody] Service service)
    {
        if (service == null)
        {
            return BadRequest();
        }
        dbc.Services.Add(service);
        dbc.SaveChangesAsync();
        return Ok();
    }


    [HttpDelete]
    public ActionResult DeleteService(int id)
    {
        Service deleteService = dbc.Services.FirstOrDefault(service => service.Id == id);
        if(deleteService == null)
        {
            return NotFound();
        }
        dbc.Services.Remove(deleteService);
        dbc.SaveChanges();
        return Ok();
    }


}
