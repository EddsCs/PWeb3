using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyect_web_def.Models
{
    public class DetallePedido
    {
        [Key]
        public int DetalleID { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoID { get; set; }

        [ForeignKey("Producto")]
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Precio Unitario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal PrecioUnitario { get; set; }

        // Propiedades de navegación
        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
    }
}
