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
            var sala = Salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
                return NotFound();
            return Ok(sala);
        }
    }
}
