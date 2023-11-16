using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_web_def.Data;
using Proyect_web_def.Models;

namespace Proyect_web_def.Controllers
{
    public class DetallePedidoesController : Controller
    {
        private readonly Proyect_web_defContext _context;

        public DetallePedidoesController(Proyect_web_defContext context)
        {
            _context = context;
        }

        // GET: DetallePedidoes
        public async Task<IActionResult> Index()
        {
            var proyect_web_defContext = _context.DetallePedido.Include(d => d.Pedido).Include(d => d.Producto);
            return View(await proyect_web_defContext.ToListAsync());
        }

        // GET: DetallePedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallePedido == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleID == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidoes/Create
        public IActionResult Create()
        {
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID");
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "NombreProducto");
            return View();
        }

        // POST: DetallePedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleID,PedidoID,ProductoID,Cantidad,PrecioUnitario")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", detallePedido.PedidoID);
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "NombreProducto", detallePedido.ProductoID);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallePedido == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", detallePedido.PedidoID);
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "NombreProducto", detallePedido.ProductoID);
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleID,PedidoID,ProductoID,Cantidad,PrecioUnitario")] DetallePedido detallePedido)
        {
            if (id != detallePedido.DetalleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.DetalleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", detallePedido.PedidoID);
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "NombreProducto", detallePedido.ProductoID);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallePedido == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleID == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallePedido == null)
            {
                return Problem("Entity set 'Proyect_web_defContext.DetallePedido'  is null.");
            }
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido != null)
            {
                _context.DetallePedido.Remove(detallePedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return (_context.DetallePedido?.Any(e => e.DetalleID == id)).GetValueOrDefault();
        }
    }
}
