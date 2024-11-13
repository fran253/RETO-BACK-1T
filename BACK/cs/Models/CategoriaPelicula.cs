namespace Models;

public class CategoriaPelicula {
    public int Id {get;set;}
    public string NombreCategoria {get;set;}



    public CategoriaPelicula(int id, string nombreCategoria) {
        Id = id;
        NombreCategoria = nombreCategoria;
        
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
