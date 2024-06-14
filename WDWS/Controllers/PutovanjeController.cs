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
    public class PutovanjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PutovanjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Putovanje
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Putovanja.Include(p => p.Smjestaj).Include(p => p.TuristickiVodic);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Putovanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanje = await _context.Putovanja
                .Include(p => p.Smjestaj)
                .Include(p => p.TuristickiVodic)
                .FirstOrDefaultAsync(m => m.travelId == id);
            if (putovanje == null)
            {
                return NotFound();
            }

            return View(putovanje);
        }

        // GET: Putovanje/Create
        public IActionResult Create()
        {
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail");
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id");
            return View();
        }

        // POST: Putovanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("travelId,mjestoPolaskaID,mjestoDolaskaID,duzinaPutovanja,datumPolaska,datumDolaska,cijenaPoOsobi,prijevoz,smjestajID,guideID,ImageURL,OpisPutovanja")] Putovanje putovanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(putovanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail", putovanje.smjestajID);
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id", putovanje.guideID);
            return View(putovanje);
        }

        // GET: Putovanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanje = await _context.Putovanja.FindAsync(id);
            if (putovanje == null)
            {
                return NotFound();
            }
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail", putovanje.smjestajID);
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id", putovanje.guideID);
            return View(putovanje);
        }

        // POST: Putovanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("travelId,mjestoPolaskaID,mjestoDolaskaID,duzinaPutovanja,datumPolaska,datumDolaska,cijenaPoOsobi,prijevoz,smjestajID,guideID,ImageURL,OpisPutovanja")] Putovanje putovanje)
        {
            if (id != putovanje.travelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(putovanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PutovanjeExists(putovanje.travelId))
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
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail", putovanje.smjestajID);
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id", putovanje.guideID);
            return View(putovanje);
        }

        // GET: Putovanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanje = await _context.Putovanja
                .Include(p => p.Smjestaj)
                .Include(p => p.TuristickiVodic)
                .FirstOrDefaultAsync(m => m.travelId == id);
            if (putovanje == null)
            {
                return NotFound();
            }

            return View(putovanje);
        }

        // POST: Putovanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var putovanje = await _context.Putovanja.FindAsync(id);
            if (putovanje != null)
            {
                _context.Putovanja.Remove(putovanje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PutovanjeExists(int id)
        {
            return _context.Putovanja.Any(e => e.travelId == id);
        }
        
        // Filtriranje na osnovu vrste prijevoza
        //potrebne su dvije funkcije: jedna za bus i jedna za avion
        public async Task<IActionResult> FilteredByPrijevoz(int a)
        {
            var filteredTrips = await _context.Putovanja
                .Include(p => p.Smjestaj)
                .Include(p => p.TuristickiVodic)
                // ovdje ide uslov provjera tip prijevoza
                .ToListAsync();
            return View("Index", filteredTrips);
        }
    }
}
