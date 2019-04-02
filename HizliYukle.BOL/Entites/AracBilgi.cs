using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("AracBilgi")]
    public class AracBilgi
    {
        [ForeignKey("Nakliyeci")]
        public int ID { get; set; }
        [StringLength(50),Column(TypeName ="varchar")]
        public string Plaka { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string Marka { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string Model { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string AracTur { get; set; }
        public virtual Nakliyeci Nakliyeci { get; set; }
       
    }
}
