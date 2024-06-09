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
    public class LokacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LokacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lokacija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lokacije.ToListAsync());
        }

        // GET: Lokacija/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacija = await _context.Lokacije
                .FirstOrDefaultAsync(m => m.postanskiBroj == id);
            if (lokacija == null)
            {
                return NotFound();
            }

            return View(lokacija);
        }

        // GET: Lokacija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nazivMjesta,drzava,postanskiBroj")] Lokacija lokacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokacija);
        }

        // GET: Lokacija/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacija = await _context.Lokacije.FindAsync(id);
            if (lokacija == null)
            {
                return NotFound();
            }
            return View(lokacija);
        }

        // POST: Lokacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nazivMjesta,drzava,postanskiBroj")] Lokacija lokacija)
        {
            if (id != lokacija.postanskiBroj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokacijaExists(lokacija.postanskiBroj))
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
            return View(lokacija);
        }

        // GET: Lokacija/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacija = await _context.Lokacije
                .FirstOrDefaultAsync(m => m.postanskiBroj == id);
            if (lokacija == null)
            {
                return NotFound();
            }

            return View(lokacija);
        }

        // POST: Lokacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lokacija = await _context.Lokacije.FindAsync(id);
            if (lokacija != null)
            {
                _context.Lokacije.Remove(lokacija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokacijaExists(string id)
        {
            return _context.Lokacije.Any(e => e.postanskiBroj == id);
        }
    }
}
