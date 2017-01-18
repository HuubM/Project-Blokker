using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBlokker.Data;
using ProjectBlokker.Models;

namespace ProjectBlokker.Views
{
    public class KleursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KleursController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Kleurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kleur.ToListAsync());
        }

        // GET: Kleurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = await _context.Kleur.SingleOrDefaultAsync(m => m.KleurID == id);
            if (kleur == null)
            {
                return NotFound();
            }

            return View(kleur);
        }

        // GET: Kleurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kleurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KleurID,Naam")] Kleur kleur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kleur);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kleur);
        }

        // GET: Kleurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = await _context.Kleur.SingleOrDefaultAsync(m => m.KleurID == id);
            if (kleur == null)
            {
                return NotFound();
            }
            return View(kleur);
        }

        // POST: Kleurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KleurID,Naam")] Kleur kleur)
        {
            if (id != kleur.KleurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kleur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KleurExists(kleur.KleurID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(kleur);
        }

        // GET: Kleurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = await _context.Kleur.SingleOrDefaultAsync(m => m.KleurID == id);
            if (kleur == null)
            {
                return NotFound();
            }

            return View(kleur);
        }

        // POST: Kleurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kleur = await _context.Kleur.SingleOrDefaultAsync(m => m.KleurID == id);
            _context.Kleur.Remove(kleur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KleurExists(int id)
        {
            return _context.Kleur.Any(e => e.KleurID == id);
        }
    }
}
