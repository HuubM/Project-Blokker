using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectBlokker.Models;
using System.Diagnostics;
using ProjectBlokker.Data;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace ProjectBlokker.Controllers
{
    public class AfspraakController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
           return View();
        }

        public ActionResult getTime(DateTime dateInput)
        {
            var tijd = _context.Afspraak;
            return View();
        }

        public ActionResult getDate()
        {
            
            var datum = _context.Afspraak.GroupBy(x => x.AfspraakDatum)
                                                   .Where(x => x.Count() > 2)
                                                   .Select(x => x.Key);

            return Json(datum);
        }

        // GET: /<controller>/
        public IActionResult AfspraakGeslaagd()
        {
            return View("AfspraakGeslaagd");
        }

    


        [HttpPost]
        public IActionResult Add(Afspraak afspraak)
        {

            if (ModelState.IsValid)
            {
               
                _context.Afspraak.Add(afspraak);
                _context.SaveChanges();

                /*var message = new MimeMessage();
                message.From.Add(new MailboxAddress("HoneyMoonShop", "HoneyMoonShop@outlook.com"));
                //message.To.Add(new MailboxAddress(@afspraak.Naam, @afspraak.Email));
                message.Subject = "Afspraak Bevestiging HoneyMoonShop";
                message.Body = new TextPart("plain")
                {
                    //Text = "Geachte " + @afspraak.Naam + "," + "\n" + "\n" + "Uw Afspraak op " + @afspraak.AfspraakDatum + " is in goede orde ontvangen." + "\n" + "\n" + "Met vriendelijke groet," +
                    //"\n" + "HoneyMoonShop"
                };

                using (SmtpClient client = new SmtpClient())//TODO takes too much time, should be multi threading 
                {
                    client.Connect("smtp.live.com", 587);
                    client.Authenticate("honeymoonshop@outlook.com", "Honeymoon"); //TODO betere security
                    client.Send(message);
                    client.Disconnect(true);
                }*/
              
            } return RedirectToAction("/AfspraakGeslaagd");
           
             
        }
        
    }
}
