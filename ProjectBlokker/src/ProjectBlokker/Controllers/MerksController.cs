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
    public class MerksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Merks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merk.ToListAsync());
        }

        // GET: Merks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merk.SingleOrDefaultAsync(m => m.MerkID == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // GET: Merks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerkID,Naam")] Merk merk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(merk);
        }

        // GET: Merks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merk.SingleOrDefaultAsync(m => m.MerkID == id);
            if (merk == null)
            {
                return NotFound();
            }
            return View(merk);
        }

        // POST: Merks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MerkID,Naam")] Merk merk)
        {
            if (id != merk.MerkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerkExists(merk.MerkID))
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
            return View(merk);
        }

        // GET: Merks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merk.SingleOrDefaultAsync(m => m.MerkID == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // POST: Merks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merk = await _context.Merk.SingleOrDefaultAsync(m => m.MerkID == id);
            _context.Merk.Remove(merk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MerkExists(int id)
        {
            return _context.Merk.Any(e => e.MerkID == id);
        }
    }
}
