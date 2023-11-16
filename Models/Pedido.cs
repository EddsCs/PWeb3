using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_web_def.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }

        [ForeignKey("Nombres")]
        public int UsuarioID { get; set; }

        public DateTime? FechaPedido { get; set; }

        public string Estado { get; set; }

       
        public Usuario Usuario { get; set; }

        
    }
}
