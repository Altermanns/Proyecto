namespace Proyecto.Models
{
    public class Vehiculo
    {
        public int IdVehiculo {  get; set; }
        public string Marca  { get; set; }
        public string Modelo { get; set; }
        public DateOnly Año { get; set; }
        public float precio { get; set; }
        public float kilometraje { get; set; }
    }
}
