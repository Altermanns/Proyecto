using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Usuario
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly FechaNacimiento { get; set; }
        [ForeignKey("IdVehiculo")]
        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public RolUsuario Rol { get; set; }
    }
}
