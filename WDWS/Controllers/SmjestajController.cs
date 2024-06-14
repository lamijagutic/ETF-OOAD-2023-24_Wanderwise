using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDWS.Data;
using wdws.Models;

namespace WDWS.Controllers
{
    public class SmjestajController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SmjestajController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Smjestaj
        [Authorize(Roles = "Administrator, Vodic")] 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Smjestaji.ToListAsync());
        }

        // GET: Smjestaj/Details/5
        [Authorize(Roles = "Administrator")] 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestaj = await _context.Smjestaji
                .FirstOrDefaultAsync(m => m.lodgingID == id);
            if (smjestaj == null)
            {
                return NotFound();
            }

            return View(smjestaj);
        }

        [Authorize(Roles = "Administrator")] 
        // GET: Smjestaj/Create
        public IActionResult Create()
        {
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            return View();
        }

        // POST: Smjestaj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lodgingID,naziv,VrstaSmjestaja,lokacijaID,KontaktTelefon,KontaktEmail,MaxKapacitet,CijenaSmjestaja")] Smjestaj smjestaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smjestaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            return View(smjestaj);
        }

        [Authorize(Roles = "Administrator")] 
        // GET: Smjestaj/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestaj = await _context.Smjestaji.FindAsync(id);
            if (smjestaj == null)
            {
                return NotFound();
            }
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            return View(smjestaj);
        }

        // POST: Smjestaj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lodgingID,naziv,VrstaSmjestaja,lokacijaID,KontaktTelefon,KontaktEmail,MaxKapacitet,CijenaSmjestaja")] Smjestaj smjestaj)
        {
            if (id != smjestaj.lodgingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smjestaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmjestajExists(smjestaj.lodgingID))
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
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");

            return View(smjestaj);
        }

        [Authorize(Roles = "Administrator")] 
        // GET: Smjestaj/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestaj = await _context.Smjestaji
                .FirstOrDefaultAsync(m => m.lodgingID == id);
            if (smjestaj == null)
            {
                return NotFound();
            }

            return View(smjestaj);
        }

        // POST: Smjestaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smjestaj = await _context.Smjestaji.FindAsync(id);
            if (smjestaj != null)
            {
                _context.Smjestaji.Remove(smjestaj);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmjestajExists(int id)
        {
            return _context.Smjestaji.Any(e => e.lodgingID == id);
        }
    }
}
