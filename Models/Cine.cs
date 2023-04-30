namespace P2Cine.Models;

public class Cine{
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }

    public int Id { get; set; }
    public virtual List<Empleado> Empleados { get; set; } = new List<Empleado>();

}