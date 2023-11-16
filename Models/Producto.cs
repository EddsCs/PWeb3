using System.ComponentModel.DataAnnotations;

namespace Proyect_web_def.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo Nombre de Producto no puede tener más de 100 caracteres.")]
        public string NombreProducto { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
    }
}
