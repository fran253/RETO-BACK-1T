namespace Models;

public class Sala {
    public int Id {get;set;}
    public int IdAsiento {get;set;}





    public Sala(int id, int idasiento) {
        Id = id;
        IdAsiento = idasiento;
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
