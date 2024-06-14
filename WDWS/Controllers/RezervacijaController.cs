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
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rezervacije.Include(r => r.Putovanje);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacije
                .Include(r => r.Putovanje)
                .FirstOrDefaultAsync(m => m.reservationID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create()
        {
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");

            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "travelId", "travelId");
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reservationID,putovanjeID,brojPutnika,ukupnaCijena,MilesBodovi,rezervisanaSobaID,status,klijentID,VodicUkljucen")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");

            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "travelId", "travelId", rezervacija.putovanjeID);
            return View(rezervacija);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacije.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");

            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "travelId", "travelId", rezervacija.putovanjeID);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reservationID,putovanjeID,brojPutnika,ukupnaCijena,MilesBodovi,rezervisanaSobaID,status,klijentID,VodicUkljucen")] Rezervacija rezervacija)
        {
            if (id != rezervacija.reservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.reservationID))
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
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");

            ViewData["putovanjeID"] = new SelectList(_context.Putovanja, "travelId", "travelId", rezervacija.putovanjeID);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacije
                .Include(r => r.Putovanje)
                .FirstOrDefaultAsync(m => m.reservationID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacije.FindAsync(id);
            if (rezervacija != null)
            {
                _context.Rezervacije.Remove(rezervacija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacije.Any(e => e.reservationID == id);
        }
    }
}
