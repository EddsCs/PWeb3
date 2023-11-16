using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyect_web_def.Models;

namespace Proyect_web_def.Data
{
    public class Proyect_web_defContext : DbContext
    {
        public Proyect_web_defContext (DbContextOptions<Proyect_web_defContext> options)
            : base(options)
        {
        }

        public DbSet<Proyect_web_def.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<Proyect_web_def.Models.Rol>? Rol { get; set; }

        public DbSet<Proyect_web_def.Models.Producto>? Producto { get; set; }

        public DbSet<Proyect_web_def.Models.Pedido>? Pedido { get; set; }

        public DbSet<Proyect_web_def.Models.DetallePedido>? DetallePedido { get; set; }
    }
}
