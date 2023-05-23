using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuliVerseny.Models;
using System;
using System.Collections.Generic;
using SuliVerseny.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuliVerseny.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IskolaController : ControllerBase
    {
        [Route("basic")]
        [HttpGet]

        public IActionResult GetBasic()
        {

            using (var context = new VersenyContext())
            {
                try
                {
                    var response = context.Iskolaks.ToList();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("advanced")]
        [HttpGet]

        public IActionResult GetAdvanced()
        {

            using (var context = new VersenyContext())
            {
                try
                {
                    var response = context.Iskolaks.Include(f => f.Iskolalogok).OrderBy(f=>f.Nev).ToList();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("filtered")]
        [HttpGet]

        public IActionResult GetFiltered(int iskolaId)
        {

            using (var context = new VersenyContext())
            {
                try
                {
                    var response = context.Iskolaks.Include(f => f.Iskolalogok).Where(f=>f.IskolaId==iskolaId).ToList();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("{uId}")]

        public IActionResult Post(string uId, Iskolak iskola)
        {
            //var result = uId == "hello" ? "igen" : "nem";
            //felhasznalo ??= new Felhasznalok();

            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        context.Iskolaks.Add(iskola);
                        context.SaveChanges();
                        return Ok("Az új iskola adatai rögzítésre kerültek.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs bejelentkezve/jogosultsága!");
            }
        }

        [HttpPut("{uId}")]

        public IActionResult Put(string uId, Iskolak iskola)
        {
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        context.Iskolaks.Update(iskola);
                        
                        context.SaveChanges();
                        return Ok("Az iskola adatai módosításra kerültek.");
                    }
                    catch (Exception ex)
                    {
                        return Ok(ex.Message);
                    }
                }
            }
            else
            {
                return Ok("Nincs bejelentkezve/jogosultsága!");
            }

        }


        [HttpDelete("{uId}")]

        public IActionResult Delete(string uId, int id)
        {
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        Iskolak iskola = new Iskolak();
                        iskola.Id = id;
                        context.Iskolaks.Remove(iskola);
                        context.SaveChanges();
                        return Ok("Az iskola adatai törlésre kerültek.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs bejelentkezve/jogosultsága!");
            }
        }
    }
}
