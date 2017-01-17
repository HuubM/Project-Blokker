using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectBlokker.Data;
using ProjectBlokker.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectBlokker.Controllers
{
    public class DressfinderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DressfinderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(List<string> merk, int sort, int id)
        {
            

            // Categorieen
            ViewBag.categorieen = _context.Categorie.ToList<Categorie>();

            // Stijlen
            ViewBag.stijlen = _context.Stijl.ToList<Stijl>();

            // Neklijnen
            ViewBag.neklijnen = _context.Neklijn.ToList<Neklijn>();

            // Silhouette
            ViewBag.silhouette = _context.Silhouette.ToList<Silhouette>();

            // Kleuren
            ViewBag.kleuren = _context.Kleur.ToList<Kleur>();

            // Merken
            ViewBag.merken = _context.Merk.ToList<Merk>();

            // Max prijs
            ViewBag.maxprijs = _context.Jurk.Max(j => j.Prijs);


            // Als id(categorie) is gezet dan halen we alleen artikelen van die categorie
            if (id != 0)
            {
                ViewBag.artikelen = _context.Artikel.Where(j => j.CategorieID == id).ToList<Artikel>();
            }
            else
            {
                ViewBag.artikelen = _context.Artikel.ToList<Artikel>();
            }
            

            List<Jurk> jurken = new List<Jurk>();

            // Haal 1 jurk van elk artikel om te laten zien
            foreach (Artikel artikel in ViewBag.artikelen)
            {
                // Haal jurk op van artikel
                Jurk jurk = _context.Jurk.Where(j => j.artikel.ArtikelID == artikel.ArtikelID).First<Jurk>();


                if (jurk != null)
                {
                    jurken.Add(jurk);
                }
            }

            ViewBag.jurken = jurken;

            
            ViewBag.test = merk.FirstOrDefault<string>();

            return View();
        }

        [HttpPost]
        public IActionResult Filter(List<int> merk, int sort, int id, List<int> stijl, List<int> neklijn, List<int> silhouette, List<int> kleur, int max, int min)
        {
            ViewBag.test = merk;
            // Categorieen
            ViewBag.categorieen = _context.Categorie.ToList<Categorie>();

            // Stijlen
            ViewBag.stijlen = _context.Stijl.ToList<Stijl>();

            // Neklijnen
            ViewBag.neklijnen = _context.Neklijn.ToList<Neklijn>();

            // Silhouette
            ViewBag.silhouette = _context.Silhouette.ToList<Silhouette>();

            // Kleuren
            ViewBag.kleuren = _context.Kleur.ToList<Kleur>();

            // Merken
            ViewBag.merken = _context.Merk.ToList<Merk>();

            // Max prijs
            ViewBag.maxprijs = _context.Jurk.Max(j => j.Prijs);


            List<Artikel> artikelen;

            // Als id(categorie) is gezet dan halen we alleen artikelen van die categorie
            if (id != 0)
            {
                artikelen = _context.Artikel.Where(j => j.CategorieID == id).ToList();
            }
            else
            {
                artikelen = _context.Artikel.ToList<Artikel>();
            }


            // Voeg aan viewbag toe
            ViewBag.artikelen = artikelen;


            List<Jurk> jurken = new List<Jurk>();

            // Haal 1 jurk van elk artikel om te laten zien
            foreach (Artikel artikel in ViewBag.artikelen)
            {
                var query = _context.Jurk.Where(j => j.artikel.ArtikelID == artikel.ArtikelID);

                // voeg meerdere condities toe als er gefilterd wordt.

                // Merk filter
                if (merk.Count() > 0)
                {
                    query = query.Where(j => merk.Contains(j.merk.MerkID));
                }
                
                // Stijl jurk filter
                if (stijl.Count() > 0)
                {
                    query = query.Where(j => stijl.Contains(j.stijl.StijlID));
                }

                //Neklijn filter
                if (neklijn.Count() > 0)
                {
                    query = query.Where(j => neklijn.Contains(j.neklijn.NeklijnID));
                }

                //silhouette filter
                if (silhouette.Count() > 0)
                {
                    query = query.Where(j => silhouette.Contains(j.silhouette.SilhouetteID));
                }

                // kleur filter
                if (kleur.Count() > 0)
                {
                    query = query.Where(j => kleur.Contains(j.kleur.KleurID));
                }

                // kleur filter
                if (min > 0)
                {
                    query = query.Where(j => j.Prijs >= min);
                }

                // kleur filter
                if (max > 0)
                {
                    query = query.Where(j => j.Prijs <= max);
                }


                Jurk jurk = query.FirstOrDefault<Jurk>();

                if (jurk != null)
                {
                    jurken.Add(jurk);
                }
            }

            // Sorteren
            if (sort != 0)
            {
                switch (sort)
                {
                    // prijs hoog naar laag
                    case 1:
                        jurken = jurken.OrderByDescending(j => j.Prijs).ToList();
                        break;
                    // prijs laag naar hoog
                    case 2:
                        jurken = jurken.OrderBy(j => j.Prijs).ToList();
                        break;
                }
            }

            ViewBag.jurken = jurken;

            return View();
        }

        public IActionResult Index(int id, int sort)
        {

            ViewBag.extrajs = "~/js/dressfinder.js";

            // Categorieen
            ViewBag.categorieen = _context.Categorie.ToList<Categorie>();

            // Stijlen
            ViewBag.stijlen = _context.Stijl.ToList<Stijl>();

            // Neklijnen
            ViewBag.neklijnen = _context.Neklijn.ToList<Neklijn>();

            // Silhouette
            ViewBag.silhouette = _context.Silhouette.ToList<Silhouette>();

            // Kleuren
            ViewBag.kleuren = _context.Kleur.ToList<Kleur>();

            // Merken
            ViewBag.merken = _context.Merk.ToList<Merk>();

            // Max prijs
            ViewBag.maxprijs = _context.Jurk.Max(j => j.Prijs);


            // Als id(categorie) is gezet dan halen we alleen artikelen van die categorie
            if (id != 0)
            {
                ViewBag.categorie = id;
                ViewBag.artikelen = _context.Artikel.Where(j => j.CategorieID == id).ToList<Artikel>();
            } else
            {
                ViewBag.artikelen = _context.Artikel.ToList<Artikel>();
            }

            List<Jurk> jurken = new List<Jurk>();

            // Haal 1 jurk van elk artikel om te laten zien
            foreach (Artikel artikel in ViewBag.artikelen)
            {
                Jurk jurk = _context.Jurk.Where(j => j.artikel.ArtikelID == artikel.ArtikelID).FirstOrDefault<Jurk>();

                if (jurk != null)
                {
                    jurken.Add(jurk);
                }
            }


            // Sorteren
            if (sort != 0)
            {
                switch (sort)
                {
                    // prijs hoog naar laag
                    case 1:
                        jurken = jurken.OrderByDescending(j => j.Prijs).ToList();
                        break;
                    // prijs laag naar hoog
                    case 2:
                        jurken = jurken.OrderBy(j => j.Prijs).ToList();
                        break;
                }
            }

            ViewBag.jurken = jurken;



            return View();
        }


        public IActionResult Jurk(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = _context.Jurk.Include(x => x.kleur).Include(x => x.merk).Include(x => x.artikel).Include(x => x.neklijn).Include(x => x.silhouette).Include(x => x.stijl).SingleOrDefault();
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }
    }
}