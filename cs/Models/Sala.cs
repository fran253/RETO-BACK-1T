namespace Models;

public class Sala {
    public int IdSala {get;set;}
    public string NombreSala {get; set;}
    public int Capacidad{get;set;}

    




    public Sala(int idsala, int capacidad, string nombresala){
        IdSala = idsala;
        Capacidad = capacidad;
        NombreSala = nombresala;

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
