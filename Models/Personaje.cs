namespace P2Cine.Models;

public class Personaje{
    public string Nombre { get; set; }
    public string Rol { get; set; }
    public int Id { get; set; }

    public Actor Actor { get; set; }
    public int ActorId { get; set; }
}