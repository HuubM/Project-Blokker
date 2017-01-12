using ProjectBlokker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.ViewModels
{
    public class JurkViewModel
    {
        public Jurk jurk { get; set; }

        public IEnumerable<Artikel> artikelen { get; set; }
    }
}
