using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectBlokker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.ViewModels
{
    public class DressfinderIndex
    {
        public Artikel artikel { get; set; }
        public Jurk jurk { get; set; }
        public Categorie categorie { get; set; }
        public Kleur kleur { get; set; }
        public Merk merk { get; set; }
        public Neklijn neklijn { get; set; }
        public Silhouette silhouette { get; set; }
        public Stijl stijl { get; set; }

        public IEnumerable<int> aantaltonen { get; set; }
    }
}
