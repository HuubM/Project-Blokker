using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieID { get; set; }
        public string Naam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }
    }
}
