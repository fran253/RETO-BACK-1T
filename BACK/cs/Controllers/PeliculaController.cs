using Microsoft.AspNetCore.Mvc;

using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private static List<Pelicula> peliculas = new List<Pelicula>();

        [HttpGet]
        public ActionResult<IEnumerable<Pelicula>> GetAll()
        {
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pelicula> GetById(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
                return NotFound();
            return Ok(pelicula);
        }

        [HttpPost]
        public ActionResult<Pelicula> Create([FromBody] Pelicula pelicula)
        {
            peliculas.Add(pelicula);
            return CreatedAtAction(nameof(GetById), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Pelicula updatedPelicula)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
                return NotFound();

            pelicula.Nombre = updatedPelicula.Nombre;
            pelicula.Duracion = updatedPelicula.Duracion;
            pelicula.Actores = updatedPelicula.Actores;
            pelicula.EdadMinima = updatedPelicula.EdadMinima;
            pelicula.FechaEstreno = updatedPelicula.FechaEstreno;
            pelicula.Horario = updatedPelicula.Horario;
            pelicula.Descripcion = updatedPelicula.Descripcion;
            pelicula.IdEntrada = updatedPelicula.IdEntrada;
            pelicula.IdSala = updatedPelicula.IdSala;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
                return NotFound();

            peliculas.Remove(pelicula);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            peliculas.Add(new Pelicula(1, "RED ONE","../imgs/RedOne.jpg","Jake Kasdan", 148, "Nick Kroll, Dwayne Johnson, Chris Evans, Kristofer Hivju, Kiernan Shipka, Bonnie Hunt, Mary Elizabeth Ellis, Wesley Kimmel, Lucy Liu, J.K. Simmons",
            "+7", new DateTime(2024, 11, 6), new DateTime(2024, 11, 9, 18, 0, 0), 
            "Tras el secuestro de Papá Noel, nombre en clave: RED ONE, el Jefe de Seguridad del Polo Norte (Dwayne Johnson) debe formar equipo con el cazarrecompensas más infame del mundo (Chris Evans) en una misión trotamundos llena de acción para salvar la Navidad. No te pierdas #RedOne, protagonizada por Dwayne Johnson y Chris Evans. Disfruta de la película a partir del 6 noviembre solo en cines.",
            1, 5, 1, "Estrenos"));      
            peliculas.Add(new Pelicula(2, "VENOM 3", "../imgs/venom3.jpg","Kelly Marcel", 138, "Rhys Ifans, Chiwetel Ejiofor, Tom Hardy, Stephen Graham, Alanna Ubach, Juno Temple, Clark Backo, Peggy Lu",
            "+12", new DateTime(2024, 10, 25), new DateTime(2024, 11, 9, 20, 30, 0), 
            "Eddie y Venom están a la fuga. Perseguidos por sus sendos mundos y cada vez más cercados, el dúo se ve abocado a tomar una decisión devastadora que hará que caiga el telón sobre el último baile de Venom y Eddie.",
            2, 1, 3,"Acción"));
            peliculas.Add(new Pelicula(3, "GLADIATOR II", "../imgs/Gladiator2.jpg","Ridley Scott", 138, "Paul Mescal, Denzel Washington, Connie Nielsen, Joseph Quinn, Derek Jacobi, Fred Hechinger, Lior Raz, Pedro Pascal",
            "+16", new DateTime(2024, 11, 15), new DateTime(2024, 11, 9, 20, 30, 0), 
            "Años después de presenciar la muerte del admirado héroe Máximo a manos de su tío, Lucio (Paul Mescal) se ve forzado a entrar en el Coliseo tras ser testigo de la conquista de su hogar por parte de los tiránicos emperadores que dirigen Roma con puño de hierro. Con un corazón desbordante de furia y el futuro del imperio en juego, Lucio debe rememorar su pasado en busca de la fuerza y el honor que devuelvan al pueblo la gloria perdida de Roma.",
            3, 4,3,"Acción"));
            peliculas.Add(new Pelicula(3, "TERRIFIER 3", "../imgs/Terrifier3.jpeg","Chris Sanders", 100, "Bill Nighy, Lupita Nyong'o, Stephanie Hsu, Mark Hamill, Ving Rhames, Matt Berry, Pedro Pascal, Kit Connor",
            "TP", new DateTime(2024, 10, 11), new DateTime(2024, 11, 9, 20, 30, 0), 
            "La película sigue el épico viaje de un robot -la unidad 7134 de Roz, 'ROZ' para abreviar- que naufraga en una isla deshabitada y debe aprender a adaptarse al duro entorno, entablando gradualmente relaciones con los animales de la isla y convirtiéndose en padre adoptivo de un gosling huérfano.",
            5, 8,3,"Terror"));
            peliculas.Add(new Pelicula(5, "DUNE: PARTE DOS", "../imgs/Dune2.jpg", "Denis Villeneuve", 155, "Timothée Chalamet, Zendaya, Rebecca Ferguson, Javier Bardem, Josh Brolin, Dave Bautista, Florence Pugh, Austin Butler, Christopher Walken",
            "+12", new DateTime(2024, 11, 3), new DateTime(2024, 11, 9, 19, 0, 0), 
            "Paul Atreides une fuerzas con los Fremen para vengar la conspiración contra su familia mientras intenta evitar un oscuro destino en el que él mismo podría transformarse en un tirano. La guerra por el control del desértico planeta de Arrakis continúa en esta espectacular segunda entrega.",
            2, 3, 1, "Ciencia Ficción"));

            peliculas.Add(new Pelicula(6, "THE BATMAN: CAPÍTULO DOS", "../imgs/TheBatman2.jpeg", "Matt Reeves", 185, "Robert Pattinson, Zoë Kravitz, Paul Dano, Colin Farrell, Jeffrey Wright, Andy Serkis, John Turturro",
            "+16", new DateTime(2025, 3, 15), new DateTime(2025, 3, 15, 21, 30, 0), 
            "La ciudad de Gotham continúa siendo un campo de batalla para Batman, quien ahora debe enfrentarse a nuevos enemigos que ponen a prueba sus habilidades, y cuestionan hasta dónde está dispuesto a llegar para proteger la ciudad.",
            3, 5, 2, "Acción"));

            peliculas.Add(new Pelicula(7, "AVATAR 3", "../imgs/Avatar3.jpg", "James Cameron", 190, "Sam Worthington, Zoe Saldaña, Sigourney Weaver, Stephen Lang, Kate Winslet, Cliff Curtis",
            "TP", new DateTime(2024, 12, 20), new DateTime(2024, 12, 20, 20, 0, 0), 
            "Jake Sully y Neytiri deben proteger a su familia cuando una antigua amenaza reaparece, poniendo en peligro todo lo que aman. La aventura en Pandora continúa con emocionantes descubrimientos y desafíos.",
            1, 7, 3, "Aventura"));

            peliculas.Add(new Pelicula(8, "SPIDER-MAN: MÁS ALLÁ DEL MULTIVERSO", "../imgs/SpiderBeyond.jpg", "Joaquim Dos Santos", 130, "Shameik Moore, Hailee Steinfeld, Oscar Isaac, Issa Rae, Jake Johnson, Daniel Kaluuya",
            "+7", new DateTime(2025, 5, 10), new DateTime(2025, 5, 10, 18, 30, 0), 
            "Miles Morales se embarca en una nueva aventura en el multiverso, enfrentándose a desafíos y aliados inesperados, en una misión que no solo pondrá en peligro su vida, sino el destino de todos los universos conocidos.",
            2, 6, 4, "Animación"));

        }



    }
}
