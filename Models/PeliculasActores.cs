namespace P2Cine.Models;

public class PeliculasActores{
    public int PeliculaId { get; set; }
    public int ActorId { get; set; }

    public Pelicula Pelicula { get; set; }
    public Actor Actor { get; set; }
}