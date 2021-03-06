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
    public class AfspraakOverviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfspraakOverviewController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public ActionResult Index(string sortOrder)
        {
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var afspraken = from s in _context.Afspraak
                           select s;
            switch (sortOrder)
            {   case "Date":
                    afspraken = afspraken.OrderBy(s => s.AfspraakDatum);
                    break;
                case "date_desc":
                    afspraken = afspraken.OrderByDescending(s => s.AfspraakDatum);
                    break;
                default:
                    afspraken = afspraken.OrderBy(s => s.Naam);
                    break;
            }
            return View(afspraken.ToList());
        }

        /* GET: AfspraakOverview
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afspraak.ToListAsync());
        }*/

        // GET: AfspraakOverview/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.ID == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // GET: AfspraakOverview/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AfspraakOverview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AfspraakDatum,AfspraakTijd,Email,Naam,Nieuwsbrief,TelNr,TrouwDatum")] Afspraak afspraak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afspraak);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(afspraak);
        }

        // GET: AfspraakOverview/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.ID == id);
            if (afspraak == null)
            {
                return NotFound();
            }
            return View(afspraak);
        }

        // POST: AfspraakOverview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AfspraakDatum,AfspraakTijd,Email,Naam,Nieuwsbrief,TelNr,TrouwDatum")] Afspraak afspraak)
        {
            if (id != afspraak.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afspraak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfspraakExists(afspraak.ID))
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
            return View(afspraak);
        }

        // GET: AfspraakOverview/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.ID == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // POST: AfspraakOverview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.ID == id);
            _context.Afspraak.Remove(afspraak);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AfspraakExists(int id)
        {
            return _context.Afspraak.Any(e => e.ID == id);
        }
    }
}
