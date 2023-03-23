using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            ViewBag.ciudades = await _context.CiudadModel.ToListAsync();
            return _context.ProductosModel != null ? 
                          View(await _context.ProductosModel.OrderBy(x => x.nombre).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProductosModel'  is null.");
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductosModel == null)
            {
                return NotFound();
            }

            var productosModel = await _context.ProductosModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (productosModel == null)
            {
                return NotFound();
            }

            return View(productosModel);
        }

        // GET: Productos/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ciudades = await _context.CiudadModel.ToListAsync();
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,cantidad,ciudad")] ProductosModel productosModel)
        {
            if (ModelState.IsValid)
            {
                var registrado = _context.ProductosModel.Where(x => x.nombre == productosModel.nombre && x.ciudad == productosModel.ciudad).FirstOrDefault();
                if (registrado == null)
                {
                    var res = _context.Add(productosModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(productosModel);
            }
            return View(productosModel);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductosModel == null)
            {
                return NotFound();
            }

            var productosModel = await _context.ProductosModel.FindAsync(id);
            if (productosModel == null)
            {
                return NotFound();
            }
            return View(productosModel);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,cantidad,ciudad")] ProductosModel productosModel)
        {
            if (id != productosModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosModelExists(productosModel.id))
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
            return View(productosModel);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductosModel == null)
            {
                return NotFound();
            }

            var productosModel = await _context.ProductosModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (productosModel == null)
            {
                return NotFound();
            }

            return View(productosModel);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductosModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductosModel'  is null.");
            }
            var productosModel = await _context.ProductosModel.FindAsync(id);
            if (productosModel != null)
            {
                _context.ProductosModel.Remove(productosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosModelExists(int id)
        {
          return (_context.ProductosModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
