namespace P2Cine.Models;

public class Actor{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }

    public int Id { get; set; }
    public Personaje Personaje { get; set; }

    public int PersonajeId { get; set; }
    public virtual List<PeliculasActores> PeliculasActores { get; set; }
}