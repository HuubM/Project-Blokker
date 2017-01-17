using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{

    public class Artikel
    {
        [Key]
        public int ArtikelID { get; set; }

        public string Naam { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieID { get; set; }


        public virtual Categorie categorie { get; set; }
        public virtual IList<Jurk> Jurken { get; set;}
    }
}
