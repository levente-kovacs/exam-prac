using Ingatlan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ingatlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ingatlan : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPopulated()
        {

            using (var context = new ingatlanContext())
            {
                try
                {
                    var response = context.Ingatlanoks.Include(f => f.KategoriaNavigation).ToList(); // toLost elé, ha kell: .OrderBy(f => f.Nev)
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpPost]
        public IActionResult Post(Ingatlanok ingatlan)
        {
            using (var context = new ingatlanContext())
            {
                try
                {
                    context.Ingatlanoks.Add(ingatlan);
                    context.SaveChanges();
                    return Ok("CREATED");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                    //return BadRequest("Hiányos adatok");
                }
            }
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            using (var context = new ingatlanContext())
            {
                try
                {
                    Ingatlanok ingatlan = new Ingatlanok();
                    ingatlan.Id = id;
                    context.Ingatlanoks.Remove(ingatlan);
                    context.SaveChanges();
                    return Ok("NO CONTENT");
                }
                catch (Exception ex)
                {
                    return StatusCode(404, "404 NOT FOUND");
                }
            }
        }



    }
}
