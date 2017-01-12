using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectBlokker.Data;
using ProjectBlokker.Models;

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

            
            ViewBag.test = merk.FirstOrDefault<string>();

            return View();
        }

        public IActionResult Index(int id, int sort)
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

        public IActionResult Jurk()
        {
            return View();
        }

    }
}