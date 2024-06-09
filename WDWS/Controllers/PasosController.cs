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
    public class PasosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PasosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pasos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasosi.ToListAsync());
        }

        // GET: Pasos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasos = await _context.Pasosi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pasos == null)
            {
                return NotFound();
            }

            return View(pasos);
        }

        // GET: Pasos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pasos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,drzavaKojaIzdaje,nacionalnost,datumIsteka,napomene")] Pasos pasos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasos);
        }

        // GET: Pasos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasos = await _context.Pasosi.FindAsync(id);
            if (pasos == null)
            {
                return NotFound();
            }
            return View(pasos);
        }

        // POST: Pasos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,drzavaKojaIzdaje,nacionalnost,datumIsteka,napomene")] Pasos pasos)
        {
            if (id != pasos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasosExists(pasos.ID))
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
            return View(pasos);
        }

        // GET: Pasos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasos = await _context.Pasosi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pasos == null)
            {
                return NotFound();
            }

            return View(pasos);
        }

        // POST: Pasos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasos = await _context.Pasosi.FindAsync(id);
            if (pasos != null)
            {
                _context.Pasosi.Remove(pasos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasosExists(int id)
        {
            return _context.Pasosi.Any(e => e.ID == id);
        }
    }
}
