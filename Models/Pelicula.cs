namespace P2Cine.Models;

public class Pelicula{
    public string Nombre { get; set; }
    public int Duracion { get; set; }
    public int Id { get; set; }
    public virtual List<PeliculasActores> PeliculasActores { get; set; }
}