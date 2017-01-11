using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlokker.Models
{
    public class Silhouette
    {
        [Key]
        public int SilhouetteID { get; set; }
        public string Naam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }
    }
}
