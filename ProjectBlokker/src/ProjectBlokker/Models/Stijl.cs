using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public class Stijl
    {
        [Key]
        public int StijlID { get; set; }
        public string Naam { get; set;}

        // Navigation
        public virtual IList<Jurk> Jurken { get; set; }
    }
}
