using WebshopWebAPI.Models;
using WebshopWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UjTipusokController : ControllerBase
{
    public UjTipusokController()
    {
    }
    [HttpPost]
public IActionResult Create(Tipusok tipus)
{            
   {            
    TipusokService.Add(tipus);
    return CreatedAtAction(nameof(Create), new { id = tipus.Id }, tipus);
}
}
}