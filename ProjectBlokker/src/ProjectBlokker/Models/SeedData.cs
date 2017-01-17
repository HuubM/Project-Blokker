using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectBlokker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public static class SeedData 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                ClearAll(context);

                IList<string> stijlenLijst = new List<string> { "Kant", "Klassieke Bruid", "Prinses Bruid", "Ruches rok", "Modieuze Bruid", "Budget Bruid" };
                SeedStijl(context, stijlenLijst);

                IList<string> neklijnLijst = new List<string> { "Boothals", "Halter", "Hoge neklijn", "Strapless", "Off-shoulder", "V-hals", "Een schouder" };
                Seedneklijn(context, neklijnLijst);

                IList<string> silhouetteLijst = new List<string> { "Princess model", "Kort", "Fishtail", "Empire", "Recht", "A-lijn", "Fit & Flare" };
                Seedsilhouette(context, silhouetteLijst);

                IList<string> kleurenLijst = new List<string> { "Ivoor", "Ivoor met kleurtint", "kleur" };
                Seedkleur(context, kleurenLijst);

                IList<string> categorieLijst = new List<string> { " SummerSale", "Nieuwste Jurken", " WinterSale" };
                Seedcategorie(context, categorieLijst);
                context.SaveChanges();

                IList<string> artikelLijst = new List<string> { "artikel1", " artikel2", "artikel3", " artikel2", "artikel3", " artikel2", "artikel3" };
                Seedartikel(context, artikelLijst, categorieLijst);
                context.SaveChanges();

                IList<string> merkenAanmaken = new List<string> {"Badgley & Mischka", "Ladybird", "Diane Legrand", "Pronovias", "Maggie Sottero"
                , "Eddy K.", "Mylene Sophie", "Demetrios", "Olvi's", "Martina Liana" };
                Seedmerk(context, merkenAanmaken);
                context.SaveChanges();

            }
        }

        private static void ClearAll(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("delete from Artikel");
            context.Database.ExecuteSqlCommand("delete from Stijl");
            context.Database.ExecuteSqlCommand("delete from Neklijn");
            context.Database.ExecuteSqlCommand("delete from Silhouette");
            context.Database.ExecuteSqlCommand("delete from Kleur");
            context.Database.ExecuteSqlCommand("delete from Categorie");
            context.Database.ExecuteSqlCommand("delete from Merk");


        }

        private static void Seedcategorie(ApplicationDbContext context, IList<string> categorieLijst)
        {
            foreach (var x in categorieLijst)
            {
                context.Categorie.Add(new Categorie() { Naam = x });
            }
        }


        private static void Seedkleur(ApplicationDbContext context, IList<string> kleurenLijst)
        {
            foreach( var x in kleurenLijst)
            {
                context.Kleur.Add(new Kleur() { Naam = x });
            }
        }

        private static void Seedsilhouette(ApplicationDbContext context, IList<string> silhouetteLijst)
        {
            foreach (var x in silhouetteLijst)
            {
                context.Silhouette.Add(new Silhouette() { Naam = x });

            }

        }

        private static void Seedneklijn(ApplicationDbContext context, IList<string> neklijnLijst)
        {
            foreach (var x in neklijnLijst)
            {
                context.Neklijn.Add(new Neklijn() { Naam = x });

            }

        }

        private static void Seedmerk(ApplicationDbContext context, IList<string> merkenLijst) 
            {
                foreach(var x in merkenLijst)
                    {
                        context.Merk.Add(new Merk() {Naam = x });

                    }

            }

        private static void SeedStijl(ApplicationDbContext context, IList<string> stijlenLijst)
        {
            foreach(var x in stijlenLijst)
            {
                context.Stijl.Add(new Stijl() { Naam = x });

            }
        }

        private static void Seedartikel(ApplicationDbContext context, IList<string> artikelLijst, IList<string> categorieLijst)
        {
            var randomNumber = new Random();
            foreach (var artikelnaam in artikelLijst)
            {

                var categorieen = context.Categorie.ToList();
                int max = categorieen.Count();
                int randCat = randomNumber.Next(0, max);

                int randomCategorieID = categorieen[randCat].CategorieID;

                Artikel artikel = new Artikel()
                {
                    Naam =  artikelnaam,
                    CategorieID = randomCategorieID
                };

                context.Artikel.Add(artikel);
            }
        }


        private static void SeedJurk(ApplicationDbContext context, int aantalJurken)
        {
            var artikelen = context.Artikel.ToList();
            var stijlen = context.Stijl.ToList();
            var neklijnen = context.Neklijn.ToList();
            var silhouetten = context.Silhouette.ToList();
            var kleuren = context.Kleur.ToList();
            var categorieen = context.Categorie.ToList();

        }
    }
}

