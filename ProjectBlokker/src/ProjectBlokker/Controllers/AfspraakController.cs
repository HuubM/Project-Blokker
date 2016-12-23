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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> Add([Bind("ID,AfspraakDatum,Email,Naam,Nieuwsbrief,TelNr,TrouwDatum")] Afspraak afspraak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afspraak);
                await _context.SaveChangesAsync();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("HoneyMoonShop", "HoneyMoonShop@outlook.com"));
                message.To.Add(new MailboxAddress(@afspraak.Naam, @afspraak.Email));
                message.Subject = "Afspraak Bevestiging HoneyMoonShop";
                message.Body = new TextPart("plain")
                {
                    Text = "Geachte " + @afspraak.Naam + "," + "\n" + "\n" + "Uw Afspraak op " + @afspraak.AfspraakDatum + " is in goede orde ontvangen." + "\n" + "\n" + "Met vriendelijke groet," + 
                    "\n" + "HoneyMoonShop" 
                };

                using (SmtpClient client = new SmtpClient())//TODO takes too much time, should be multi threading 
                {
                    client.Connect("smtp.live.com", 587);
                    client.Authenticate("honeymoonshop@outlook.com", "Honeymoon"); //TODO betere security
                    client.Send(message);
                    client.Disconnect(true);
                }

            }

            return RedirectToAction("/AfspraakGeslaagd");
        }
        
    }
}
