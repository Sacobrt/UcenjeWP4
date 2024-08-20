using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HttpMetodeController : ControllerBase
    {
        // ovdje počinje ruta
        [HttpGet]
        public string Pozdravi()
        {
            return "Hello";
        }
        // ovdje završava ruta

        // ovdje počinje ruta
        [HttpGet]
        [Route("pozdrav")]
        public string Pozdravi(string s)
        {
            return "Hello " + s;
        }
        // ovdje završava ruta

        // ovdje počinje ruta
        [HttpGet]
        [Route("hello")]
        public IActionResult Pozdravi(int id, string ime)
        {
            return Ok(new { sifra = id, naziv = ime });
        }
        // ovdje završava ruta

        // ovdje počinje ruta
        [HttpPost]
        public IActionResult Post()
        {
            return BadRequest("Nešto ne valja");
        }
        // ovdje završava ruta

        // ovdje počinje ruta
        [HttpPut]
        public IActionResult Put(Osoba osoba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            osoba.Ime = osoba.Ime + " promjenio";
            return StatusCode(StatusCodes.Status202Accepted, osoba);
        }
        // ovdje završava ruta

        // ovdje počinje ruta
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return NotFound("Nije pronađeno u bazi");
        }
        // ovdje završava ruta
    }
}
