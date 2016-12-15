using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectBlokker.Models;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectBlokker.Controllers
{
    public class AfspraakController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult test(Afspraak afspraak)
        {
            
            return View(afspraak);
        }


    }
}
