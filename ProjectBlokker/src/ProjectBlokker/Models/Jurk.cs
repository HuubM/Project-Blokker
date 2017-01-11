using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{


    public class Jurk
    {
        [Key]
        public int JurkID { get; set; }

        //public int ArtikelID { get; set; }
        //public int MerkID { get; set; }
        //public int CategorieID { get; set; }
        //public int StijlID { get; set; }
        public int Prijs { get; set; }
        //public int NeklijnID { get; set; }
        //public int SilhouetteID { get; set; }
        //public int KleurID { get; set; }
        public string Omschrijving { get; set; }


        // Naviagtion properties
        [ForeignKey("Silhouette")]
        public virtual Silhouette silhouette { get; set; }

        [ForeignKey("Neklijn")]
        public virtual Neklijn neklijn { get; set; }

        [ForeignKey("Merk")]
        public virtual Merk merk { get; set; }

        [ForeignKey("Stijl")]
        public virtual Stijl stijl { get; set; }

        [ForeignKey("Kleur")]
        public virtual Kleur kleur { get; set; }

        [ForeignKey("Categorie")]
        public virtual Categorie categorie { get; set; }
    }
}
