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
    public class StijlsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StijlsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stijls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stijl.ToListAsync());
        }

        // GET: Stijls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stijl = await _context.Stijl.SingleOrDefaultAsync(m => m.StijlID == id);
            if (stijl == null)
            {
                return NotFound();
            }

            return View(stijl);
        }

        // GET: Stijls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stijls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StijlID,Naam")] Stijl stijl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stijl);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stijl);
        }

        // GET: Stijls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stijl = await _context.Stijl.SingleOrDefaultAsync(m => m.StijlID == id);
            if (stijl == null)
            {
                return NotFound();
            }
            return View(stijl);
        }

        // POST: Stijls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StijlID,Naam")] Stijl stijl)
        {
            if (id != stijl.StijlID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stijl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StijlExists(stijl.StijlID))
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
            return View(stijl);
        }

        // GET: Stijls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stijl = await _context.Stijl.SingleOrDefaultAsync(m => m.StijlID == id);
            if (stijl == null)
            {
                return NotFound();
            }

            return View(stijl);
        }

        // POST: Stijls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stijl = await _context.Stijl.SingleOrDefaultAsync(m => m.StijlID == id);
            _context.Stijl.Remove(stijl);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StijlExists(int id)
        {
            return _context.Stijl.Any(e => e.StijlID == id);
        }
    }
}
