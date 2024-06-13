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
    public class KlijentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlijentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klijent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klijenti.ToListAsync());
        }

        // GET: Klijent/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // GET: Klijent/Create
        public IActionResult Create()
        {
            ViewBag.Spol = new SelectList(GetSpol());
            return View();
        }

        // POST: Klijent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kontaktZaHitneSlucajeve,napomene,nagradniBodovi,ime,prezime,adresa,spol,datumRodjenja,pozicija,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klijent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Spol = new SelectList(GetSpol());
            return View(klijent);
        }

        // GET: Klijent/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijenti.FindAsync(id);
            if (klijent == null)
            {
                return NotFound();
            }
            return View(klijent);
        }

        // POST: Klijent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("kontaktZaHitneSlucajeve,napomene,nagradniBodovi,ime,prezime,adresa,spol,datumRodjenja,pozicija,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Klijent klijent)
        {
            if (id != klijent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klijent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlijentExists(klijent.Id))
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
            return View(klijent);
        }

        // GET: Klijent/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // POST: Klijent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var klijent = await _context.Klijenti.FindAsync(id);
            if (klijent != null)
            {
                _context.Klijenti.Remove(klijent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlijentExists(string id)
        {
            return _context.Klijenti.Any(e => e.Id == id);
        }
        
        private List<string> GetSpol(){
            return new List<string> 
            {
                "Muški",
                "Ženski"
            };
        }
    }
}
