using ProjectBlokker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.ViewModels
{
    public class ArtikelViewModel
    {
        public Artikel artikel { get; set; }

        public IEnumerable<Categorie> categorie { get; set; }



    }
}
