using Euroskills.DTOModels;
using Euroskills.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Euroskills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EuSkill : ControllerBase
    {
        private readonly string UID = "FKB3F4FEA09CE43C";

        [HttpGet("getVersenyzoK")]
        public IActionResult GetAll()
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    // DTO
                    var res = context.Versenyzos.Include(f => f.Orszag).ToList();
                    List<VersenyzoDTO> versenyzoDTOs = new List<VersenyzoDTO>();
                    foreach (var item in res)
                    {
                        VersenyzoDTO versenyzoDTO = new VersenyzoDTO();
                        versenyzoDTO.OrszagNev = item.Orszag.OrszagNev;
                        versenyzoDTO.Nev = item.Nev;
                        versenyzoDTO.Pont = item.Pont;
                        versenyzoDTOs.Add(versenyzoDTO);
                    }
                    return Ok(versenyzoDTOs);

                    // NORMÁL
                    //return Ok(context.Versenyzos.Include(f => f.Orszag).ToList());
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }


        [HttpGet("getVersenyzo/{id}")]
        public IActionResult GetAll(int id)
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    // DTO
                    //var res = context.Versenyzos.Where(v => v.Id == id).Include(f => f.Orszag).First();
                    //VersenyzoDTO versenyzoDTO = new VersenyzoDTO();
                    //versenyzoDTO.OrszagNev = res.Orszag.OrszagNev;
                    //versenyzoDTO.Nev = res.Nev;
                    //versenyzoDTO.Pont = res.Pont;
                    //return Ok(versenyzoDTO);

                    // NORMÁL
                    return Ok(context.Versenyzos.Where(v => v.Id == id).ToList()); // .tolist helyett .first
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }


        [HttpGet("osszesorszagSzama")]
        public IActionResult GetAllCOuntryCount()
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    return Ok($"Összes ország száma: {context.Orszags.ToList().Count}");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }


        [HttpPost("osszesorszagSzama")]
        public IActionResult GetAllCountryCount(string UserID, Versenyzo versenyzo)
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    if (UserID == UID)
                    {
                        context.Versenyzos.Add(versenyzo);
                        context.SaveChanges();
                        return StatusCode(201, "Versenyző hozzáadása sikeresen megtörtént.");
                    }
                    else
                    {
                        return StatusCode(404, "Helytelen azonosító!");

                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }


        [HttpPut("updateVersenyzo/{id}")]
        public IActionResult updateVersenyzo(int id, Versenyzo versenyzo)
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    versenyzo.Id = id;
                    context.Versenyzos.Update(versenyzo);
                    context.SaveChanges();
                    return StatusCode(200, "Versenyző adatai sikeresen módosítva.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }


        [HttpDelete("deleteVersenyzo/{id}")]
        public IActionResult DeleteVersenyzo(int id)
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    Versenyzo versenyzo = new Versenyzo();
                    versenyzo.Id = id;
                    context.Versenyzos.Remove(versenyzo);
                    context.SaveChanges();
                    return StatusCode(204, "Versenyző törlése sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }

    }
}
