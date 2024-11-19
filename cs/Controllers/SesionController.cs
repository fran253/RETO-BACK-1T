using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();

        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetAll()
        {
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Sesion> GetById(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
            if (sesion == null)
                return NotFound();
            return Ok(sesion);
        }

        [HttpPost]
        public ActionResult<Sesion> Create([FromBody] Sesion nuevaSesion)
        {
            nuevaSesion.IdSesion = sesiones.Count + 1;
            sesiones.Add(nuevaSesion);
            return CreatedAtAction(nameof(GetById), new { id = nuevaSesion.IdSesion }, nuevaSesion);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Sesion sesionActualizada)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
            if (sesion == null)
                return NotFound();

            sesion.IdAsiento = sesionActualizada.IdAsiento;
            sesion.IdEntrada = sesionActualizada.IdEntrada;
            sesion.IdPelicula = sesionActualizada.IdPelicula;
            sesion.idSala = sesionActualizada.idSala;
            sesion.AsientosDisponibles = sesionActualizada.AsientosDisponibles;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
            if (sesion == null)
                return NotFound();

            sesiones.Remove(sesion);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            sesiones.Add(new Sesion(
                idsesion: 1,
                asiento: new Asiento(),
                entrada: new Entrada(),
                pelicula: new Pelicula(1, "RED ONE", "../imgs/RedOne.jpg", "Jake Kasdan", 148, "Nick Kroll, Dwayne Johnson", "+7", new DateTime(2024, 11, 6), new DateTime(2024, 11, 9, 18, 0, 0), "Sinopsis", 1),
                sala: new Sala(2, 100,"A-4")
            ));
            // Puedes añadir más sesiones iniciales de manera similar
        }
    }
}
