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
            Artikel art = new Artikel()
            {
                 Naam = "Mooie Jurk"
            };


            _context.Artikel.Add(art);
            _context.SaveChanges();

            return View();
        }
    }
}