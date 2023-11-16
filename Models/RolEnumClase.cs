using System.ComponentModel.DataAnnotations;

namespace Proyect_web_def.Models
{
    public class RolEnumClase
    {
        public enum RolEnum
        {
            [Display(Name = "Administrador")]
            Administrador = 2,

            [Display(Name = "Empleado")]
            Empleado = 3
        }
    }
}
