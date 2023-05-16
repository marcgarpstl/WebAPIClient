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
    public List<Service> GetObjects()
    {
        return dbc.Services.ToList();
    }
    // GET: api/Services/{id}
    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        Service service = dbc.Services.Find(id);
        if(service == null)
        {
            return NotFound();
        }
        return service;
    }
    [HttpPut]
    public ActionResult UpdateService([FromBody] UpdateArgs service)
    {
        if (service == null)
        {
            return BadRequest();
        }
        Service serviceUpdate = dbc.Services.FirstOrDefault(service => service.Id == service.Id);
        if (serviceUpdate == null)
        {
            return NotFound();
        }

        serviceUpdate.Name = service.Name;
        serviceUpdate.Price = service.Price;
        serviceUpdate.Description = service.Description;
        serviceUpdate.IsAvalible = service.IsAvalible;
        dbc.SaveChanges();
        return Ok();
    }
}
