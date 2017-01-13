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

        // GET: /<controller>/
        public IActionResult AfspraakGeslaagd()
        {
            return View("AfspraakGeslaagd");
        }

    


        [HttpPost]
        public IActionResult Add(Afspraak afspraak)
        {
            
            /*foreach (var modelStateValue in ViewData.ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    // Do something useful with these properties
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;
                    Console.WriteLine(errorMessage);
                    Console.WriteLine(exception);
                }
            }*/

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
               
            }
           return RedirectToAction("/AfspraakGeslaagd");
             
        }
        
    }
}
