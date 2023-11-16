using System.ComponentModel.DataAnnotations;

namespace Proyect_web_def.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Rol es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Nombre de Rol no puede tener más de 50 caracteres.")]
        public string NombreRol { get; set; }

    }
  
}