using SQLitePCL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_web_def.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Correo no es una dirección de correo electrónico válida.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Clave es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Clave no puede tener más de 50 caracteres.")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "El campo IdRol es obligatorio.")]
        public int IdRol { get; set; }

        // Propiedad de navegación para representar la relación con la tabla Roles
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }

        // Campo IdRolEnum ahora es nullable
      // public RolEnumClase.RolEnum? IdRolEnum { get; set; }
      
      
    }
}
