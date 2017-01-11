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
    public class NeklijnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NeklijnsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Neklijns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Neklijn.ToListAsync());
        }

        // GET: Neklijns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neklijn = await _context.Neklijn.SingleOrDefaultAsync(m => m.NeklijnID == id);
            if (neklijn == null)
            {
                return NotFound();
            }

            return View(neklijn);
        }

        // GET: Neklijns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Neklijns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NeklijnID,Naam")] Neklijn neklijn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neklijn);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(neklijn);
        }

        // GET: Neklijns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neklijn = await _context.Neklijn.SingleOrDefaultAsync(m => m.NeklijnID == id);
            if (neklijn == null)
            {
                return NotFound();
            }
            return View(neklijn);
        }

        // POST: Neklijns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NeklijnID,Naam")] Neklijn neklijn)
        {
            if (id != neklijn.NeklijnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neklijn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeklijnExists(neklijn.NeklijnID))
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
            return View(neklijn);
        }

        // GET: Neklijns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neklijn = await _context.Neklijn.SingleOrDefaultAsync(m => m.NeklijnID == id);
            if (neklijn == null)
            {
                return NotFound();
            }

            return View(neklijn);
        }

        // POST: Neklijns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neklijn = await _context.Neklijn.SingleOrDefaultAsync(m => m.NeklijnID == id);
            _context.Neklijn.Remove(neklijn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NeklijnExists(int id)
        {
            return _context.Neklijn.Any(e => e.NeklijnID == id);
        }
    }
}
