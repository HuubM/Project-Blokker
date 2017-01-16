using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBlokker.Data;
using ProjectBlokker.Models;
using ProjectBlokker.ViewModels;

namespace ProjectBlokker.Controllers
{
    public class ArtikelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtikelsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Artikels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Artikel.Include(a => a.categorie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Artikels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel.SingleOrDefaultAsync(m => m.ArtikelID == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // GET: Artikels/Create
        public IActionResult Create()
        {
            ArtikelViewModel avm = new ArtikelViewModel();
            avm.artikel = artikel;
            avm.categorie = _context.Categorie.ToList<Categorie>();

            return View(avm);
        }

        // POST: Artikels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikel);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ArtikelViewModel avm = new ArtikelViewModel();
            avm.categorie = _context.Categorie.ToList<Categorie>();
            
            return View(avm);
        }

        // GET: Artikels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel.SingleOrDefaultAsync(m => m.ArtikelID == id);
            if (artikel == null)
            {
                return NotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieID", artikel.CategorieID);
            return View(artikel);
        }

        // POST: Artikels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtikelID,CategorieID,Naam")] Artikel artikel)
        {
            if (id != artikel.ArtikelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtikelExists(artikel.ArtikelID))
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
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieID", artikel.CategorieID);
            return View(artikel);
        }

        // GET: Artikels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel.SingleOrDefaultAsync(m => m.ArtikelID == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // POST: Artikels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artikel = await _context.Artikel.SingleOrDefaultAsync(m => m.ArtikelID == id);
            _context.Artikel.Remove(artikel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ArtikelExists(int id)
        {
            return _context.Artikel.Any(e => e.ArtikelID == id);
        }
    }
}
