using WebshopWebAPI.Models;
using WebshopWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebshopWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipusokController : ControllerBase
{
    public TipusokController()
    {
    }
  [HttpGet]
    public ActionResult<List<Tipusok>> GetAll() =>
    TipusokService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Tipusok> Get(int id)
    {
    var tipus = TipusokService.Get(id);

    if(tipus == null)
        return NotFound();

    return tipus;
    }
}
