using System.Data;

namespace Models;

public class Sesion {
    public int IdSesion {get;set;}
    public Asiento Asiento {get;set;}
    public Entrada Entrada {get;set;}
    public Pelicula Pelicula {get;set;}
    public Sala Sala {get;set;}
    public List<Asiento> AsientosDisponibles { get; set; }


    public Sesion(int idsesion, Asiento asiento, Entrada entrada, Pelicula pelicula, Sala sala) {
        IdSesion = idsesion;
        Asiento = asiento;
        Entrada = entrada;
        Pelicula = pelicula;
        Sala = sala;


        AsientosDisponibles = new List<Asiento>();
        for (int i = 1; i <= Sala.Capacidad; i++)
        {
            AsientosDisponibles.Add(new Asiento(i,i,false));
        }


        // if (string.IsNullOrEmpty(nombre))
        // {
        //     throw new ArgumentException("Error: El nombre no puede estar vacío.");
        // }
        // if (precio < 0)
        // {
        //     throw new ArgumentException("Error: El precio no puede ser negativo.");
        // }
    }

    //public abstract void MostrarDetalles();

}
