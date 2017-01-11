using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBlokker.Data;
using ProjectBlokker.Models;

namespace ProjectBlokker.Controllers
{
    public class JurksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JurksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Jurks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jurk.ToListAsync());
        }

        // GET: Jurks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }

        // GET: Jurks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jurks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JurkID,ArtikelID,CategorieID,KleurID,MerkID,NeklijnID,Omschrijving,Prijs,SilhouetteID,StijlID")] Jurk jurk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jurk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jurk);
        }

        // GET: Jurks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }
            return View(jurk);
        }

        // POST: Jurks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JurkID,ArtikelID,CategorieID,KleurID,MerkID,NeklijnID,Omschrijving,Prijs,SilhouetteID,StijlID")] Jurk jurk)
        {
            if (id != jurk.JurkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jurk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JurkExists(jurk.JurkID))
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
            return View(jurk);
        }

        // GET: Jurks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }

        // POST: Jurks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.JurkID == id);
            _context.Jurk.Remove(jurk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JurkExists(int id)
        {
            return _context.Jurk.Any(e => e.JurkID == id);
        }
    }
}
