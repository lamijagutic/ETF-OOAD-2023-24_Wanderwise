using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDWS.Data;
using wdws.Models;

namespace WDWS.Controllers
{
    public class RecenzijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecenzijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recenzija
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recenzije.Include(r => r.putovanje);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recenzija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzija = await _context.Recenzije
                .Include(r => r.putovanje)
                .FirstOrDefaultAsync(m => m.RecenzijaID == id);
            if (recenzija == null)
            {
                return NotFound();
            }

            return View(recenzija);
        }

        // GET: Recenzija/Create
        public IActionResult Create()
        {
            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "ID", "ID");
            return View();
        }

        // POST: Recenzija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecenzijaID,tekstRecenzije,putovanjeID")] Recenzija recenzija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recenzija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "ID", "ID", recenzija.putovanjeID);
            return View(recenzija);
        }

        // GET: Recenzija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzija = await _context.Recenzije.FindAsync(id);
            if (recenzija == null)
            {
                return NotFound();
            }
            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "ID", "ID", recenzija.putovanjeID);
            return View(recenzija);
        }

        // POST: Recenzija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecenzijaID,tekstRecenzije,putovanjeID")] Recenzija recenzija)
        {
            if (id != recenzija.RecenzijaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recenzija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecenzijaExists(recenzija.RecenzijaID))
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
            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "ID", "ID", recenzija.putovanjeID);
            return View(recenzija);
        }

        // GET: Recenzija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzija = await _context.Recenzije
                .Include(r => r.putovanje)
                .FirstOrDefaultAsync(m => m.RecenzijaID == id);
            if (recenzija == null)
            {
                return NotFound();
            }

            return View(recenzija);
        }

        // POST: Recenzija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recenzija = await _context.Recenzije.FindAsync(id);
            if (recenzija != null)
            {
                _context.Recenzije.Remove(recenzija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecenzijaExists(int id)
        {
            return _context.Recenzije.Any(e => e.RecenzijaID == id);
        }
    }
}
