using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{   
    public class CiudadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CiudadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ciudad
        public async Task<IActionResult> Index()
        {
              return _context.CiudadModel != null ? 
                          View(await _context.CiudadModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CiudadModel'  is null.");
        }

        // GET: Ciudad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CiudadModel == null)
            {
                return NotFound();
            }

            var ciudadModel = await _context.CiudadModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ciudadModel == null)
            {
                return NotFound();
            }

            return View(ciudadModel);
        }

        // GET: Ciudad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descripcion")] CiudadModel ciudadModel)
        {
            if (ModelState.IsValid)
            {
                var val = _context.CiudadModel.Where(m => m.descripcion== ciudadModel.descripcion).FirstOrDefault();
                if (val == null)
                {
                    _context.Add(ciudadModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(ciudadModel);
            }
            return View(ciudadModel);
        }

        // GET: Ciudad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CiudadModel == null)
            {
                return NotFound();
            }

            var ciudadModel = await _context.CiudadModel.FindAsync(id);
            if (ciudadModel == null)
            {
                return NotFound();
            }
            return View(ciudadModel);
        }

        // POST: Ciudad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descripcion")] CiudadModel ciudadModel)
        {
            if (id != ciudadModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudadModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadModelExists(ciudadModel.id))
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
            return View(ciudadModel);
        }

        // GET: Ciudad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CiudadModel == null)
            {
                return NotFound();
            }

            var ciudadModel = await _context.CiudadModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ciudadModel == null)
            {
                return NotFound();
            }

            return View(ciudadModel);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CiudadModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CiudadModel'  is null.");
            }
            var ciudadModel = await _context.CiudadModel.FindAsync(id);
            if (ciudadModel != null)
            {
                _context.CiudadModel.Remove(ciudadModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadModelExists(int id)
        {
          return (_context.CiudadModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
