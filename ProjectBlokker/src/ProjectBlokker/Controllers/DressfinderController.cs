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

        public IActionResult Index()
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

            // Artikelen
            ViewBag.artikelen = _context.Artikel.ToList<Artikel>();

            List<Jurk> jurken = new List<Jurk>();

            // Haal 1 jurk van elk artikel om te laten zien
            foreach (Artikel artikel in ViewBag.artikelen)
            {
                Jurk jurk = _context.Jurk.Where(j => j.artikel.ArtikelID == artikel.ArtikelID).First<Jurk>();

                jurken.Add(jurk);
            }

            ViewBag.jurken = jurken;
            

            return View();
        }
    }
}