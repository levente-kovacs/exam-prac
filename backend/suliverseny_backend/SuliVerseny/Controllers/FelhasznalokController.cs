using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuliVerseny.Models;
using System;
using System.Collections.Generic;
using SuliVerseny.Interfaces;
using System.Linq;

namespace SuliVerseny.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase, IGet
    {
        [HttpGet("{uId}")]

        public IActionResult Get(string uId)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {*/
                using (var context = new VersenyContext())
                {
                    try
                    {
                        List<Felhasznalok> felhasznaloks = new List<Felhasznalok>(context.Felhasznaloks);
                        return Ok(felhasznaloks);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            /*}
            else
            {
                return BadRequest("Nincs bejelentkezve/jogosultsága!");
            }*/
        }

        [HttpPost("{uId}")]

        public IActionResult Post(string uId, Felhasznalok felhasznalo)
        {
            //var result = uId == "hello" ? "igen" : "nem";
            //felhasznalo ??= new Felhasznalok();

            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        context.Felhasznaloks.Add(felhasznalo);
                        context.SaveChanges();
                        return Ok("Az új felhasználó adatai rögzítésre kerültek.");
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

        public IActionResult Put(string uId, Felhasznalok felhasznalo)
        {
            if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].Jogosultsag == 9)
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        context.Felhasznaloks.Update(felhasznalo);
                        context.SaveChanges();
                        return Ok("A felhasználó adatai módosításra kerültek.");
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
                        Felhasznalok felhasznalo = new Felhasznalok();
                        felhasznalo.Id = id;
                        context.Felhasznaloks.Remove(felhasznalo);
                        context.SaveChanges();
                        return Ok("A felhasználó adatai törlésre kerültek.");
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

        [HttpDelete]
        public IActionResult DeleteUserName(string uId, string userName)
        {
            if (Program.LoggedInUsers.ContainsKey(uId))
            {
                using (var context = new VersenyContext())
                {
                    try
                    {
                        var felhasznalok = context.Felhasznaloks.Where(f => f.FelhasznaloNev == userName).ToList();
                        if (felhasznalok.Count > 0)
                        {
                            context.Felhasznaloks.Remove(felhasznalok[0]);
                            context.SaveChanges();
                            return Ok("A bejelentkezési és személyes adatai törlésre kerültek.");
                        }
                        else
                        {
                            return StatusCode(210, "Nincs ilyen nevű felhasználó!");
                        }
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
