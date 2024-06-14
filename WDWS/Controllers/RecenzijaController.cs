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
    public class RecenzijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecenzijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recenzija
        [Authorize(Roles = "Administrator, Vodic")] 
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recenzije.Include(r => r.Putovanje);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recenzija/Details/5
        [Authorize(Roles = "Administrator, Vodic, Klijent")] 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzija = await _context.Recenzije
                .Include(r => r.Putovanje)
                .FirstOrDefaultAsync(m => m.reviewID == id);
            if (recenzija == null)
            {
                return NotFound();
            }

            return View(recenzija);
        }

        // GET: Recenzija/Create
        [Authorize(Roles = "Klijent")] 
        public IActionResult Create()
        {
            ViewBag.Putovanja = new SelectList(_context.Putovanja, "travelId", "nazivPutovanja");
            ViewData["putID"] = new SelectList(_context.Putovanja, "travelId", "travelId");
            return View();
        }

        // POST: Recenzija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reviewID,tekstRecenzije,putID,clientID")] Recenzija recenzija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recenzija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Putovanja = new SelectList(_context.Putovanja, "travelId", "nazivPutovanja");
            ViewData["putID"] = new SelectList(_context.Putovanja, "travelId", "travelId", recenzija.putID);
            return View(recenzija);
        }

        // GET: Recenzija/Edit/5
        [Authorize(Roles = "Klijent")] 
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
            ViewBag.Putovanja = new SelectList(_context.Putovanja, "travelId", "nazivPutovanja");
            ViewData["putID"] = new SelectList(_context.Putovanja, "travelId", "travelId", recenzija.putID);
            return View(recenzija);
        }

        // POST: Recenzija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reviewID,tekstRecenzije,putID,clientID")] Recenzija recenzija)
        {
            if (id != recenzija.reviewID)
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
                    if (!RecenzijaExists(recenzija.reviewID))
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
            ViewBag.Putovanja = new SelectList(_context.Putovanja, "travelId", "nazivPutovanja");
            ViewData["putID"] = new SelectList(_context.Putovanja, "travelId", "travelId", recenzija.putID);
            return View(recenzija);
        }

        // GET: Recenzija/Delete/5
        [Authorize(Roles = "Administrator, Klijent")] 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzija = await _context.Recenzije
                .Include(r => r.Putovanje)
                .FirstOrDefaultAsync(m => m.reviewID == id);
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
            return _context.Recenzije.Any(e => e.reviewID == id);
        }
        
       

    }
}
