using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Transaccion
    {
        [Key]
        public int IdTransaccion { get; set; }

        [Required]
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        [Required]
        public int CompradorId { get; set; }
        public Usuario Comprador { get; set; }

        [Required]
        public int VendedorId { get; set; }
        public Usuario Vendedor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }

        [Required]
        public double PrecioVenta { get; set; }
    }

}
