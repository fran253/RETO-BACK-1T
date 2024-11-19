using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();
        private static int ultimoIdSesion = 0; //variable que permite añadir sesiones  que el id se cambie automaticamente


        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetAll()
        {
            return Ok(sesiones);
        }

        //filtrado por el id de la sesion
        [HttpGet("{id}")]
        public ActionResult<Sesion> GetById(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
            if (sesion == null)
                return NotFound();
            return Ok(sesion);
        }

        //Filtrado por el id de la pelicula
        [HttpGet("Pelicula/{peliculaId}")]
        public ActionResult<IEnumerable<Sesion>> GetByPeliculaId(int peliculaId)
        {
            var sesionesFiltradas = sesiones.Where(s => s.Pelicula.IdPelicula == peliculaId).ToList();
            if (sesionesFiltradas == null)
                return NotFound();
            return Ok(sesionesFiltradas);
        }


        [HttpPost]
        public ActionResult<Sesion> Create([FromBody] Sesion nuevaSesion)
        {
            // Genera un nuevo ID único
            nuevaSesion.IdSesion = ++ultimoIdSesion;
            sesiones.Add(nuevaSesion);
            return CreatedAtAction(nameof(GetById), new { id = nuevaSesion.IdSesion }, nuevaSesion);
        }
        
///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el UPDATE
        // [HttpPut("{id}")]
        // public ActionResult Update(int id, [FromBody] Sesion sesionActualizada)
        // {
        //     var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
        //     if (sesion == null)
        //         return NotFound();

        //     sesion.Pelicula = sesionActualizada.Pelicula;
        //     sesion.Sala = sesionActualizada.Sala;
        //     sesion.AsientosDisponibles = sesionActualizada.AsientosDisponibles;

        //     return NoContent();
        // }


///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el DELETE
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
        //     if (sesion == null)
        //         return NotFound();

        //     sesiones.Remove(sesion);
        //     return NoContent();
        // }

        public static void InicializarDatos()
{
    // Sesiones para cada película en todas las salas
    int idSesion = 1; // Comienza donde terminó el ID de RED ONE

    var peliculas = new List<Pelicula>
    {
        new Pelicula(1, "RED ONE","../imgs/RedOne.jpg","Jake Kasdan", 148, "Nick Kroll, Dwayne Johnson, Chris Evans, Kristofer Hivju, Kiernan Shipka, Bonnie Hunt, Mary Elizabeth Ellis, Wesley Kimmel, Lucy Liu, J.K. Simmons","+7", new DateTime(2024, 11, 6), "Tras el secuestro de Papá Noel, nombre en clave: RED ONE, el Jefe de Seguridad del Polo Norte (Dwayne Johnson) debe formar equipo con el cazarrecompensas más infame del mundo (Chris Evans) en una misión trotamundos llena de acción para salvar la Navidad. No te pierdas #RedOne, protagonizada por Dwayne Johnson y Chris Evans. Disfruta de la película a partir del 6 noviembre solo en cines.",1),      
        new Pelicula(2, "VENOM 3", "../imgs/venom3.jpg", "Kelly Marcel", 138, "Rhys Ifans, Chiwetel Ejiofor, Tom Hardy, Stephen Graham, Alanna Ubach, Juno Temple, Clark Backo, Peggy Lu", "+12", new DateTime(2024, 10, 25), "Eddie y Venom están a la fuga. Perseguidos por sus sendos mundos y cada vez más cercados, el dúo se ve abocado a tomar una decisión devastadora que hará que caiga el telón sobre el último baile de Venom y Eddie.", 2),
        new Pelicula(3, "GLADIATOR II", "../imgs/Gladiator2.jpg", "Ridley Scott", 138, "Paul Mescal, Denzel Washington, Connie Nielsen, Joseph Quinn...", "+16", new DateTime(2024, 11, 15), "Años después de presenciar la muerte del admirado héroe Máximo a manos de su tío, Lucio (Paul Mescal) se ve forzado a entrar en el Coliseo tras ser testigo de la conquista de su hogar por parte de los tiránicos emperadores que dirigen Roma con puño de hierro. Con un corazón desbordante de furia y el futuro del imperio en juego, Lucio debe rememorar su pasado en busca de la fuerza y el honor que devuelvan al pueblo la gloria perdida de Roma.", 3),
        new Pelicula(4, "TERRIFIER 3", "../imgs/Terrifier3.jpeg", "Chris Sanders", 100, "Bill Nighy, Lupita Nyong'o, Stephanie Hsu, Mark Hamill...", "TP", new DateTime(2024, 10, 11), "La película sigue el épico viaje de un robot -la unidad 7134 de Roz, 'ROZ' para abreviar- que naufraga en una isla deshabitada y debe aprender a adaptarse al duro entorno, entablando gradualmente relaciones con los animales de la isla y convirtiéndose en padre adoptivo de un gosling huérfano.", 5),
        new Pelicula(5, "DUNE: PARTE DOS", "../imgs/Dune2.jpg", "Denis Villeneuve", 155, "Timothée Chalamet, Zendaya, Rebecca Ferguson, Javier Bardem...", "+12", new DateTime(2024, 11, 3), "Paul Atreides une fuerzas con los Fremen para vengar la conspiración contra su familia mientras intenta evitar un oscuro destino en el que él mismo podría transformarse en un tirano. La guerra por el control del desértico planeta de Arrakis continúa en esta espectacular segunda entrega.", 2),
        new Pelicula(6, "THE BATMAN: CAPÍTULO DOS", "../imgs/TheBatman2.jpeg", "Matt Reeves", 185, "Robert Pattinson, Zoë Kravitz, Paul Dano...", "+16", new DateTime(2025, 3, 15), "La ciudad de Gotham continúa siendo un campo de batalla para Batman, quien ahora debe enfrentarse a nuevos enemigos que ponen a prueba sus habilidades, y cuestionan hasta dónde está dispuesto a llegar para proteger la ciudad.", 3),
        new Pelicula(7, "AVATAR 3", "../imgs/Avatar3.jpg", "James Cameron", 190, "Sam Worthington, Zoe Saldaña, Sigourney Weaver...", "TP", new DateTime(2024, 12, 20), "Jake Sully y Neytiri deben proteger a su familia cuando una antigua amenaza reaparece, poniendo en peligro todo lo que aman. La aventura en Pandora continúa con emocionantes descubrimientos y desafíos.", 1),
        new Pelicula(8, "SPIDER-MAN: MÁS ALLÁ DEL MULTIVERSO", "../imgs/SpiderBeyond.jpg", "Joaquim Dos Santos", 130, "Shameik Moore, Hailee Steinfeld, Oscar Isaac...", "+7", new DateTime(2025, 5, 10), "Miles Morales se embarca en una nueva aventura en el multiverso, enfrentándose a desafíos y aliados inesperados, en una misión que no solo pondrá en peligro su vida, sino el destino de todos los universos conocidos.", 2)
    };

    var salas = new List<Sala>
    {
        new Sala(1, 100, "A-1"),
        new Sala(2, 80, "A-2"),
        new Sala(3, 80, "A-3"),
        new Sala(4, 100, "A-4"),
        new Sala(5, 100, "B-1"),
        new Sala(6, 80, "B-2"),
        new Sala(7, 80, "B-3"),
        new Sala(8, 100, "B-4"),
        new Sala(9, 100, "C-1"),
        new Sala(10, 80, "C-2"),
        new Sala(11, 80, "C-3"),
        new Sala(12, 100, "C-4")
    };

    // ID para sesiones y horarios
    int idHorario = 1;

    foreach (var pelicula in peliculas)
    {
        // Horarios para cada película
        var horarios = new List<Horario>
        {
            new Horario(idHorario++, new DateTime(2024, 11, 6, 18, 0, 0), salas[0]),
            new Horario(idHorario++, new DateTime(2024, 11, 6, 20, 30, 0), salas[1]),
            new Horario(idHorario++, new DateTime(2024, 11, 7, 17, 0, 0), salas[2]),
            new Horario(idHorario++, new DateTime(2024, 11, 7, 19, 30, 0), salas[3])
        };

        // Crear una sesión con múltiples horarios
        sesiones.Add(new Sesion(
            idsesion: idSesion++,
            pelicula: pelicula,
            horarios: horarios
        ));
}


    }
}
}
