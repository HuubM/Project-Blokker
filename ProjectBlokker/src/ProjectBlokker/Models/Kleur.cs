using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public class Kleur
    {
        [Key]
        public int KleurID { get; set; }
        public string Naam { get; set; }
    }
}
