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

        [HttpGet]
        public ActionResult pickedDate(int afspraakdag, int afspraakmaand, int afspraakjaar)
        {
            DateTime tempDate = new DateTime(afspraakjaar, afspraakmaand, afspraakdag);
            //tempDate = new DateTime(2017, 12, 12, 0, 0, 0);
            //DateTime dbDate = new DateTime(afspraakDate);

            var buttonTijden = from tijden in _context.Afspraak
                               where tijden.AfspraakDatum == tempDate
                               select tijden.AfspraakTijd;
            // ViewBag.tijds = buttonTijden;
            //var arr = buttonTijden.ToArray();


            return Json(buttonTijden);
        }
        //haalt de datum uit de database waarvan deze meer dan 2 keer voorkomt
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

    

        // De bericht functie werkt goed. Het feit is alleen dat outlook dit account geblokkeerd heeft omdat dit geassocieerd werd met spam.
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
