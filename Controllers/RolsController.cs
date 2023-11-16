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
    public class RolsController : Controller
    {
        private readonly Proyect_web_defContext _context;

        public RolsController(Proyect_web_defContext context)
        {
            _context = context;
        }

        // GET: Rols
        public async Task<IActionResult> Index()
        {
            return _context.Rol != null ?
                        View(await _context.Rol.ToListAsync()) :
                        Problem("Entity set 'Proyect_web_defContext.Rol'  is null.");
        }

        // GET: Rols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol
                .FirstOrDefaultAsync(m => m.RolID == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: Rols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RolID,NombreRol")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: Rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RolID,NombreRol")] Rol rol)
        {
            if (id != rol.RolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.RolID))
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
            return View(rol);
        }

        // GET: Rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol
                .FirstOrDefaultAsync(m => m.RolID == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rol == null)
            {
                return Problem("Entity set 'Proyect_web_defContext.Rol'  is null.");
            }
            var rol = await _context.Rol.FindAsync(id);
            if (rol != null)
            {
                _context.Rol.Remove(rol);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolExists(int id)
        {
            return (_context.Rol?.Any(e => e.RolID == id)).GetValueOrDefault();
        }
    }
}
