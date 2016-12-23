using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public class Afspraak
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Afspraakdatum is verplicht.")]
        public DateTime AfspraakDatum { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Trouwdatum is verplicht.")]
        public DateTime TrouwDatum { get; set; }
        public int? TelNr { get; set; }
        
        [Required(ErrorMessage = "E-mailadres is verplicht.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool Nieuwsbrief { get; set; }
    }
}
