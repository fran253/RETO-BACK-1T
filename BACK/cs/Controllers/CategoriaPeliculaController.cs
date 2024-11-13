using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class CategoriaPeliculaController : ControllerBase
    {
        private static List<CategoriaPelicula> categoriapeliculas = new List<CategoriaPelicula>();

        public CategoriaPeliculaController()
        {
            if (categoriapeliculas.Count == 0)
            {
                InicializarDatos();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaPelicula>> GetAll()
        {
            return Ok(categoriapeliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaPelicula> GetById(int id)
        {
            var categoriaPelicula = categoriapeliculas.FirstOrDefault(p => p.Id == id);
            if (categoriaPelicula == null)
                return NotFound();
            return Ok(categoriaPelicula);
        }

        [HttpPost]
        public ActionResult<CategoriaPelicula> Create([FromBody] CategoriaPelicula categoriaPelicula)
        {
            categoriapeliculas.Add(categoriaPelicula);
            return CreatedAtAction(nameof(GetById), new { id = categoriaPelicula.Id }, categoriaPelicula);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CategoriaPelicula updatedCategoriaPelicula)
        {
            var categoriaPelicula = categoriapeliculas.FirstOrDefault(p => p.Id == id);
            if (categoriaPelicula == null)
                return NotFound();

            categoriaPelicula.NombreCategoria = updatedCategoriaPelicula.NombreCategoria;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoriaPelicula = categoriapeliculas.FirstOrDefault(p => p.Id == id);
            if (categoriaPelicula == null)
                return NotFound();

            categoriapeliculas.Remove(categoriaPelicula);
            return NoContent();
        }

        private static void InicializarDatos()
        {
            categoriapeliculas.Add(new CategoriaPelicula(1, "Estrenos"));
            categoriapeliculas.Add(new CategoriaPelicula(2, "Aventura"));
            categoriapeliculas.Add(new CategoriaPelicula(3, "Terror"));
            categoriapeliculas.Add(new CategoriaPelicula(4, "Ciencia Ficción"));
            categoriapeliculas.Add(new CategoriaPelicula(5, "Animación"));
        }
    }
}
