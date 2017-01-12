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

        [ForeignKey("Artikel")]
        public int ArtikelID { get; set; }

        [ForeignKey("Merk")]
        public int MerkID { get; set; }

        [ForeignKey("Stijl")]
        public int StijlID { get; set; }
        public int Prijs { get; set; }

        [ForeignKey("Neklijn")]
        public int NeklijnID { get; set; }

        [ForeignKey("Silhouette")]
        public int SilhouetteID { get; set; }

        [ForeignKey("Kleur")]
        public int KleurID { get; set; }
        public string Omschrijving { get; set; }


        public string image1_location { get; set; }
        public string image2_location { get; set; }
        public string image3_location { get; set; }
        public string image4_location { get; set; }


        // Naviagtion properties

        public virtual Artikel artikel { get; set; }
        public virtual Silhouette silhouette { get; set; }
        public virtual Neklijn neklijn { get; set; }
        public virtual Merk merk { get; set; }
        public virtual Stijl stijl { get; set; }
        public virtual Kleur kleur { get; set; }
        
    }
}
