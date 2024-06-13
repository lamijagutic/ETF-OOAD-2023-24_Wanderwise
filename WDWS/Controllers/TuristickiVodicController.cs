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
    public class TuristickiVodicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TuristickiVodicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TuristickiVodic
        public async Task<IActionResult> Index()
        {
            return View(await _context.TuristickiVodici.ToListAsync());
        }

        // GET: TuristickiVodic/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistickiVodic = await _context.TuristickiVodici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turistickiVodic == null)
            {
                return NotFound();
            }

            return View(turistickiVodic);
        }

        // GET: TuristickiVodic/Create
        public IActionResult Create()
        {
            ViewBag.Jezici = new SelectList(Getjezici());
            return View();
        }

        // POST: TuristickiVodic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jezici,dostupnost,ime,prezime,adresa,spol,datumRodjenja,pozicija,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] TuristickiVodic turistickiVodic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turistickiVodic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Jezici = new SelectList(Getjezici());
            return View(turistickiVodic);
        }

        // GET: TuristickiVodic/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistickiVodic = await _context.TuristickiVodici.FindAsync(id);
            if (turistickiVodic == null)
            {
                return NotFound();
            }
            return View(turistickiVodic);
        }

        // POST: TuristickiVodic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("jezici,dostupnost,ime,prezime,adresa,spol,datumRodjenja,pozicija,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] TuristickiVodic turistickiVodic)
        {
            if (id != turistickiVodic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turistickiVodic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristickiVodicExists(turistickiVodic.Id))
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
            return View(turistickiVodic);
        }

        // GET: TuristickiVodic/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistickiVodic = await _context.TuristickiVodici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turistickiVodic == null)
            {
                return NotFound();
            }

            return View(turistickiVodic);
        }

        // POST: TuristickiVodic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var turistickiVodic = await _context.TuristickiVodici.FindAsync(id);
            if (turistickiVodic != null)
            {
                _context.TuristickiVodici.Remove(turistickiVodic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristickiVodicExists(string id)
        {
            return _context.TuristickiVodici.Any(e => e.Id == id);
        }
        private List<string> Getjezici()
        {
            return new List<string> { "Engleski", "Njemački", "Francuski", "Turski", "Italijanski" };
        }
    }
}
