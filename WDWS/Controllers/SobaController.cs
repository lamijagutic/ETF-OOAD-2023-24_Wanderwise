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
    public class SobaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SobaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator, Vodic")] 
        // GET: Soba
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sobe.Include(s => s.Smjestaj);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Administrator, Vodic")] 
        // GET: Soba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Sobe
                .Include(s => s.Smjestaj)
                .FirstOrDefaultAsync(m => m.roomID == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        [Authorize(Roles = "Administrator, Vodic")] 
        // GET: Soba/Create
        public IActionResult Create()
        {
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "lodgingID");
            return View();
        }

        // POST: Soba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("roomID,tipSobe,kapacitetSobe,cijena,smjestajID")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "lodgingID", soba.smjestajID);
            return View(soba);
        }

        [Authorize(Roles = "Administrator, Vodic")] 
        // GET: Soba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Sobe.FindAsync(id);
            if (soba == null)
            {
                return NotFound();
            }
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "lodgingID", soba.smjestajID);
            return View(soba);
        }

        // POST: Soba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("roomID,tipSobe,kapacitetSobe,cijena,smjestajID")] Soba soba)
        {
            if (id != soba.roomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobaExists(soba.roomID))
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
            ViewData["smjestajID"] = new SelectList(_context.Smjestaji, "lodgingID", "lodgingID", soba.smjestajID);
            return View(soba);
        }

        [Authorize(Roles = "Administrator, Vodic")] 
        // GET: Soba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Sobe
                .Include(s => s.Smjestaj)
                .FirstOrDefaultAsync(m => m.roomID == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // POST: Soba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soba = await _context.Sobe.FindAsync(id);
            if (soba != null)
            {
                _context.Sobe.Remove(soba);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SobaExists(int id)
        {
            return _context.Sobe.Any(e => e.roomID == id);
        }
    }
}
