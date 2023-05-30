using Kerényi_Róbert_BackEnd_6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kerényi_Róbert_BackEnd_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EuSkill : ControllerBase
    {
        [HttpGet("getVersenyzoK")]

        public async Task<IActionResult> getVersenyzoK()
        {

            try
            {
                using (var context = new euroskillsContext())
                {
                    return StatusCode(200, await context.Versenyzos.ToArrayAsync());
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(400, ex.Message);
            }

        }

        [HttpGet("getVersenyzo/{id}")]

        public async Task<IActionResult> getVersenyzo(int id)
        {

            try
            {
                using (var context = new euroskillsContext())
                {
                    var adat = await context.Versenyzos.Where(f => f.Id == id).ToListAsync();
                    return StatusCode(200, adat[0]);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(400, ex.Message);
            }

        }

        [HttpGet("osszesOrszagSzama")]

        public async Task<IActionResult> osszesOrszagSzama()
        {

            try
            {
                using (var context = new euroskillsContext())
                {
                    var adat = await context.Orszags.ToListAsync();
                    return StatusCode(200, adat.Count);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(400, ex.Message);
            }

        }


        [HttpPost("addVersenyzo/{UserID}")]

        public async Task<IActionResult> addVersenyzo(string UserID, Versenyzo versenyzo)
        {

            try
            {
                using (var context = new euroskillsContext())
                {
                    if (UserID == Program.UID)
                    {
                        context.Versenyzos.Add(versenyzo);
                        context.SaveChanges();
                        return StatusCode(200, "Versenyző hozzáadása sikeresen megtörtént.");
                    }
                    else
                    {
                        return StatusCode(404, "Helytelen azonosító!");
                    }
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(400, ex.Message);
            }

        }

        [HttpDelete("deleteVersenyzo/{id}")]

        public IActionResult deleteVersenyzo(int id)
        {
            try
            {
                using (var context = new euroskillsContext())
                {
                    Versenyzo versenyzo = new Versenyzo();
                    versenyzo.Id = id;
                    context.Versenyzos.Remove(versenyzo);
                    context.SaveChanges();
                    return StatusCode(200, "A versenyző adatai sikeresen törlve.");
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(400, ex.Message);
            }

        }
    }
}
