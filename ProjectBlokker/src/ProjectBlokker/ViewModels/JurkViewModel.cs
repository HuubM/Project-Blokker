using Microsoft.AspNetCore.Http;
using ProjectBlokker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.ViewModels
{
    public class JurkViewModel
    {
        public Jurk jurk { get; set; }
        public IEnumerable<Artikel> artikelen { get; set; }

        public IEnumerable<Categorie> categorieen { get; set; }
        public IEnumerable<Kleur> kleuren { get; set; }

        public IEnumerable<Merk> merken { get; set; }
        public IEnumerable<Neklijn> neklijnen { get; set; }
        public IEnumerable<Silhouette> silhouettes { get; set; }
        public IEnumerable<Stijl> stijlen { get; set; }

        public IFormFile plaatje1 { get; set; }
        public IFormFile plaatje2 { get; set; }
        public IFormFile plaatje3 { get; set; }
    }
}
