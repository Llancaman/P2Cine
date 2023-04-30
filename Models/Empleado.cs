namespace P2Cine.Models;

public class Empleado{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public int Documento { get; set; }
    public int Id { get; set; }

    public Cine Cine { get; set; }

    public int CineId { get; set; }

}