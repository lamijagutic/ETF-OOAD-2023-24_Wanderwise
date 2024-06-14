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

        // GET: PutovanjeHelp/Details/5
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

        // GET: PutovanjeHelp/Create
        public IActionResult Create()
        {
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail");
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id");
            return View();
        }

        // POST: PutovanjeHelp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("travelId,mjestoPolaskaID,mjestoDolaskaID,duzinaPutovanja,nazivPutovanja,datumPolaska,datumDolaska,cijenaPoOsobi,prijevoz,smjestajID,guideID,ImageURL,OpisPutovanja")] Putovanje putovanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(putovanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");

            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail", putovanje.smjestajID);
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id", putovanje.guideID);
            return View(putovanje);
        }

        // GET: PutovanjeHelp/Edit/5
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
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail", putovanje.smjestajID);
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id", putovanje.guideID);
            return View(putovanje);
        }

        // POST: PutovanjeHelp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("travelId,mjestoPolaskaID,mjestoDolaskaID,duzinaPutovanja,nazivPutovanja,datumPolaska,datumDolaska,cijenaPoOsobi,prijevoz,smjestajID,guideID,ImageURL,OpisPutovanja")] Putovanje putovanje)
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
            ViewBag.Lokacije = new SelectList(_context.Lokacije, "postanskiBroj", "nazivMjesta");
            ViewBag.Smjestaji = new SelectList(_context.Smjestaji, "lodgingID", "naziv");
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "KontaktEmail", putovanje.smjestajID);
            ViewData["guideID"] = new SelectList(_context.TuristickiVodici, "Id", "Id", putovanje.guideID);
            return View(putovanje);
        }

        // GET: PutovanjeHelp/Delete/5
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

        // POST: PutovanjeHelp/Delete/5
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
        
        // Filtriranje na osnovu vrste prijevoza (FilteredByPrijevoz podijeljena na slj dvije metode)
        
        public async Task<IActionResult> BusPutovanja(int a)
        {
            var filteredTrips = await _context.Putovanja
                .Where(p => p.prijevoz==PrijevoznoSredstvo.Autobus)
                .ToListAsync();
            return View("Index", filteredTrips);
        }
        public async Task<IActionResult> AvioPutovanja(int a)
        {
            var filteredTrips = await _context.Putovanja
                .Include(p => p.Smjestaj)
                .Include(p => p.TuristickiVodic)
                .Where(p => p.prijevoz==PrijevoznoSredstvo.Avion)
                .ToListAsync();
            return View("Index", filteredTrips);
        }

    }
}
