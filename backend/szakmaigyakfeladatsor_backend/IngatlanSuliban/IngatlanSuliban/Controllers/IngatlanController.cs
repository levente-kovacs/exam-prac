using IngatlanSuliban.DTOs;
using IngatlanSuliban.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IngatlanSuliban.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngatlanController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPopulated()
        {
            using (var context = new ingatlanContext())
            {
                try
                {
                    var response = context.Ingatlanoks.Include(f => f.KategoriaNavigation).ToList(); // toLost elé, ha kell: .OrderBy(f => f.Nev)
                    List<IngatlanDTO> ingatlanDTOs = new List<IngatlanDTO>();
                    foreach (var item in response)
                    {
                        IngatlanDTO ingatlanDTO = new IngatlanDTO();
                        ingatlanDTO.Id = item.Id;
                        ingatlanDTO.Kategoria = item.KategoriaNavigation.Nev;
                        ingatlanDTO.Leiras = item.Leiras;
                        ingatlanDTO.HirdetesDatuma= item.HirdetesDatuma;
                        ingatlanDTO.Tehermentes = item.Tehermentes;
                        ingatlanDTO.Ar = item.Ar;
                        ingatlanDTO.KepUrl = item.KepUrl;
                        ingatlanDTOs.Add(ingatlanDTO);
                    }
                    return StatusCode(200, ingatlanDTOs);
                }
                catch (Exception ex)
                {
                    return StatusCode(400,ex.Message);
                }
            }
        }


        [HttpPost]
        public IActionResult PostPopulated(Ingatlanok ingatlan)
        {
            try
            {
                using (var context = new ingatlanContext())
                {
                    context.Ingatlanoks.Add(ingatlan);
                    context.SaveChanges();
                    return StatusCode(201, "id: 7");
                }
            }
            catch
            {
                return BadRequest("Hiányos adatok");
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
                    return StatusCode(204, "NO CONTENT");
                }
                catch (Exception ex)
                {
                    return StatusCode(404, "Az ingatlan nem létezik.");
                }
            }
        }

    }
}
