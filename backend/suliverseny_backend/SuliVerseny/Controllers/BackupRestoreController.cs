using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SuliVerseny.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BackupRestoreController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _conf;

        public BackupRestoreController(IWebHostEnvironment env, IConfiguration conf)
        {
            _env = env;
            _conf = conf;
        }

        [Route("SQLBackup/{fileName}")]
        [HttpGet]

        public async Task<ActionResult> SQLBackup(string fileName)
        {
            string hibaUzenet = "";
            string sqlDataSource = _conf.GetConnectionString("Default");
            MySqlCommand command = new MySqlCommand();
            MySqlBackup backup = new MySqlBackup(command);
            using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
            {
                try
                {
                    command.Connection = myConnection;
                    myConnection.Open();
                    var filePath = "SQLBackupRestore/" + fileName;
                    backup.ExportToFile(filePath);
                    myConnection.Close();
                    if (System.IO.File.Exists(filePath))
                    {
                        var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
                        return File(bytes, "text/plain", Path.GetFileName(filePath));
                    }
                    else
                    {
                        hibaUzenet = "Nincs ilyen file!";
                        byte[] a = new byte[hibaUzenet.Length];
                        for (int i = 0; i < hibaUzenet.Length; i++)
                        {
                            a[i] = Convert.ToByte(hibaUzenet[i]);
                        }
                        return File(a, "text/plain", "Error.txt");
                    }

                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }

        [Route("SqlRestore")]
        [HttpPost]

        public JsonResult SQLRestore()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var filePath = _env.ContentRootPath + "/SQLBackupRestore" + fileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string sqlDataSource = _conf.GetConnectionString("Default");
                MySqlCommand command = new MySqlCommand();
                MySqlBackup restore = new MySqlBackup(command);
                using (MySqlConnection mySqlConnection = new MySqlConnection(sqlDataSource))
                {
                    try
                    {
                        command.Connection = mySqlConnection;
                        mySqlConnection.Open();
                        restore.ImportFromFile(filePath);
                        System.IO.File.Delete(filePath);
                        return new JsonResult("A visszaállítás sikeresen lefutott.");
                    }
                    catch
                    {
                        return new JsonResult("Mentésfájl sikeresen feltöltve. Az sql szerver nem érhető el!");
                    }
                }
            }
            catch (Exception)
            {
                return new JsonResult("Nincs kiválasztva mentés fájl!");
            }
        }
    }
}
