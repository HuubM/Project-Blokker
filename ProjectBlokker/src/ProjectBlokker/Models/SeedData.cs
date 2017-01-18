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

                SeedJurk(context, 20);
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
            context.Database.ExecuteSqlCommand("delete from Jurk");


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
            var merken = context.Merk.ToList();
            var artikelen = context.Artikel.ToList();
            var stijlen = context.Stijl.ToList();
            var neklijnen = context.Neklijn.ToList();
            var silhouetten = context.Silhouette.ToList();
            var kleuren = context.Kleur.ToList();
            var categorieen = context.Categorie.ToList();

            var images = new List<string>() { "jurk1.jpg", "jurk2.jpg", "jurk3.jpg", "jurk4.jpg", "jurk5.jpg", "jurk6.jpg", "jurk7.jpg", "jurk8.jpg", "jurk9.jpg", "jurk10.jpg", "jurk11.jpg", "jurk12.jpg" };
            var omschrijvingen = new List<string>() {
                "Trouwjurk van het merk Badgley & Mischka gemaakt satijn. De top heeft een V-hals en een laag uitgesneden rug, beide afgewerkt met beading. De jurk kan gedragen worden met een cape. De rok heeft een fishtail model met een sleep. De sleep is afgewerkt met tule en is verdeeld in lagen.",
                "Trouwjurk van het merk Ladybird gemaakt van kant. De top heeft een V-hals met schouderbanden en een laag uitgesneden rug, afgewerkt met kanten applicaties. De rok heeft een fishtail model en de sleep is verwerkt in verschillende lagen. ",
                "Trouwjurk van het merk Ladybird gemaakt van organza. De top heeft een hoge neklijn en een laag uitgesneden rug, afgewerkt met kanten applicaties. De taille wordt geaccentueerd door drapperie. De rok heeft een A-lijn met sleep.",
                "Trouwjurk van het merk Ladybird gemaakt van organza. De top is strapless en is afgewerkt met kanten applicaties. De taille wordt geaccentueerd door een gekleurde bies, applicaties en drapperie. De jurk heeft een A-lijn met een sleep en kan gedragen worden met een bolero.",
                "Bruidsjapon van Ladybird in taft en tule. De japon is met een grote tule rok. Het lijfje is met baleinen en afgezet met kant. De japon is verkrijgbaar met jasje met korte mouwen."
            };

            var randomNummer = new Random();

            for (int i = 0; i < aantalJurken; i++)
            {

                Jurk jurk = new Jurk()
                {
                    ArtikelID = artikelen[randomNummer.Next(artikelen.Count)].ArtikelID,
                    MerkID = merken[randomNummer.Next(merken.Count)].MerkID,
                    StijlID = stijlen[randomNummer.Next(stijlen.Count)].StijlID,
                    Prijs = randomNummer.Next(10000),
                    NeklijnID = neklijnen[randomNummer.Next(neklijnen.Count)].NeklijnID,
                    SilhouetteID = silhouetten[randomNummer.Next(silhouetten.Count)].SilhouetteID,
                    KleurID = kleuren[randomNummer.Next(kleuren.Count)].KleurID,
                    Omschrijving = omschrijvingen[randomNummer.Next(omschrijvingen.Count)],
                    image1_location = images[randomNummer.Next(images.Count)],
                    image2_location = images[randomNummer.Next(images.Count)],
                    image3_location = images[randomNummer.Next(images.Count)]


                };
                context.Jurk.Add(jurk);


            }
        }
    }
}

