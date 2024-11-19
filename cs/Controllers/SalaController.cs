using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SalaController : ControllerBase
    {
        private static List<Sala> Salas = new List<Sala>();

        [HttpGet]
        public ActionResult<IEnumerable<Sala>> GetAll()
        {
            return Ok(Salas);
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> GetById(int id)
        {
            var sala = Salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound();
            return Ok(sala);
        }
                public static void InicializarDatos(){
                    Salas.Add(new Sala(1, 100,"A-1"));
                    Salas.Add(new Sala(2, 80,"A-2"));
                    Salas.Add(new Sala(1, 80,"A-3"));
                    Salas.Add(new Sala(2, 100,"A-4"));

                }

    }
}
