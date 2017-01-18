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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ProjectBlokker.Controllers
{
    public class JurksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public JurksController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        // GET: Jurks
        public IActionResult Index()
        {       

            return View(_context.Jurk.Include(x => x.kleur).Include(x => x.merk).Include(x => x.artikel).Include(x => x.neklijn).Include(x => x.silhouette).Include(x => x.stijl).ToList<Jurk>());
     
        }

        // GET: Jurks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.Include(x => x.kleur).Include(x => x.merk).Include(x => x.artikel).Include(x => x.neklijn).Include(x => x.silhouette).Include(x => x.stijl).SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);

        }

        // GET: Jurks/Create
        public IActionResult Create()
        {
            JurkViewModel jvm = new JurkViewModel();
            jvm.artikelen = _context.Artikel.ToList<Artikel>();
            jvm.categorieen = _context.Categorie.ToList<Categorie>();
            jvm.kleuren = _context.Kleur.ToList<Kleur>();
            jvm.merken = _context.Merk.ToList<Merk>();
            jvm.neklijnen = _context.Neklijn.ToList<Neklijn>();
            jvm.silhouettes = _context.Silhouette.ToList<Silhouette>();
            jvm.stijlen = _context.Stijl.ToList<Stijl>();
            return View(jvm);
        }

        // POST: Jurks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JurkViewModel jvm)
        {

            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "images/jurk");

                if (jvm.plaatje1 != null && jvm.plaatje1.Length > 0) 
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, jvm.plaatje1.FileName), FileMode.Create))
                    {
                        jvm.plaatje1.CopyTo(fileStream);
                        jvm.jurk.image1_location = jvm.plaatje1.FileName;
                    }
                }


                if (jvm.plaatje2 != null && jvm.plaatje2.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, jvm.plaatje2.FileName), FileMode.Create))
                    {
                        
                        jvm.plaatje2.CopyTo(fileStream);
                        jvm.jurk.image2_location = jvm.plaatje2.FileName;
                    }
                }

                if (jvm.plaatje3 != null && jvm.plaatje3.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, jvm.plaatje3.FileName), FileMode.Create))
                    {
                        jvm.plaatje1.CopyTo(fileStream);
                        jvm.jurk.image3_location = jvm.plaatje3.FileName;
                    }
                }


                _context.Jurk.Add(jvm.jurk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            //JurkViewModel jvm = new JurkViewModel();
            //jvm.jurk = jurk;
            jvm.artikelen = _context.Artikel.ToList<Artikel>();
            jvm.categorieen = _context.Categorie.ToList<Categorie>();
            jvm.kleuren = _context.Kleur.ToList<Kleur>();
            jvm.merken = _context.Merk.ToList<Merk>();
            jvm.neklijnen = _context.Neklijn.ToList<Neklijn>();
            jvm.silhouettes = _context.Silhouette.ToList<Silhouette>();
            jvm.stijlen = _context.Stijl.ToList<Stijl>();

            return View(jvm);
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

            JurkViewModel jvm = new JurkViewModel();

            jvm.jurk = jurk;
            jvm.artikelen = _context.Artikel.ToList<Artikel>();
            jvm.categorieen = _context.Categorie.ToList<Categorie>();
            jvm.kleuren = _context.Kleur.ToList<Kleur>();
            jvm.merken = _context.Merk.ToList<Merk>();
            jvm.neklijnen = _context.Neklijn.ToList<Neklijn>();
            jvm.silhouettes = _context.Silhouette.ToList<Silhouette>();
            jvm.stijlen = _context.Stijl.ToList<Stijl>();
            return View(jvm);
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

            JurkViewModel jvm = new JurkViewModel();

            jvm.jurk = jurk;
            jvm.artikelen = _context.Artikel.ToList<Artikel>();
            jvm.categorieen = _context.Categorie.ToList<Categorie>();
            jvm.kleuren = _context.Kleur.ToList<Kleur>();
            jvm.merken = _context.Merk.ToList<Merk>();
            jvm.neklijnen = _context.Neklijn.ToList<Neklijn>();
            jvm.silhouettes = _context.Silhouette.ToList<Silhouette>();
            jvm.stijlen = _context.Stijl.ToList<Stijl>();
            return View(jvm);
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
