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
    public class IskolaLogoController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {

            using (var context = new VersenyContext())
            {
                try
                {
                    return Ok(context.Iskolalogoks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("{uId}")]

        public IActionResult Post(string uId, Iskolalogok iskolalogo)
        {
            //var result = uId == "hello" ? "igen" : "nem";
            //felhasznalo ??= new Felhasznalok();

            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        context.Iskolalogoks.Add(iskolalogo);
                        context.SaveChanges();
                        return Ok("Az új iskolalogo rögzítésre került.");
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

        public IActionResult Put(string uId, Iskolalogok iskolalogo)
        {
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        context.Iskolalogoks.Update(iskolalogo);
                        context.SaveChanges();
                        return Ok("Az iskola logo adatai módosításra kerültek.");
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


        [HttpDelete("{uId}")]

        public IActionResult Delete(string uId, int id)
        {
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        Iskolalogok iskolalogo = new Iskolalogok();
                        iskolalogo.Id = id;
                        context.Iskolalogoks.Remove(iskolalogo);
                        context.SaveChanges();
                        return Ok("Az iskola logo adatai törlésre kerültek.");
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
