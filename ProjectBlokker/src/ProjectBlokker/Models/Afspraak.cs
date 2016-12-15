using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public class Afspraak
    {
        public Afspraak() { }

        public int ID { get; set; }
        public DateTime AfspraakDatum { get; set; }
        public string Naam { get; set; }
        public DateTime TrouwDatum { get; set; }
        public int TelNr { get; set; }
        public string Email { get; set; }
        public bool Nieuwsbrief { get; set; }
    }
}
