using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2Cine.Data;
using P2Cine.Models;

namespace P2Cine.Controllers
{
    public class CineController : Controller
    {
        private readonly CineContext _context;

        public CineController(CineContext context)
        {
            _context = context;
        }

        // GET: Cine
        public async Task<IActionResult> Index()
        {
              return _context.Cines != null ? 
                          View(await _context.Cines.ToListAsync()) :
                          Problem("Entity set 'CineContext.Cine'  is null.");
        }

        // GET: Cine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cines == null)
            {
                return NotFound();
            }

            var cine = await _context.Cines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cine == null)
            {
                return NotFound();
            }

            return View(cine);
        }

        // GET: Cine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Ubicacion,Id")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cine);
        }

        // GET: Cine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cines == null)
            {
                return NotFound();
            }

            var cine = await _context.Cines.FindAsync(id);
            if (cine == null)
            {
                return NotFound();
            }
            return View(cine);
        }

        // POST: Cine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Ubicacion,Id")] Cine cine)
        {
            if (id != cine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CineExists(cine.Id))
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
            return View(cine);
        }

        // GET: Cine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cines == null)
            {
                return NotFound();
            }

            var cine = await _context.Cines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cine == null)
            {
                return NotFound();
            }

            return View(cine);
        }

        // POST: Cine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cines == null)
            {
                return Problem("Entity set 'CineContext.Cine'  is null.");
            }
            var cine = await _context.Cines.FindAsync(id);
            if (cine != null)
            {
                _context.Cines.Remove(cine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CineExists(int id)
        {
          return (_context.Cines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
