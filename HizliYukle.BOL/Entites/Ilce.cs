using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("Ilce")]
    public class Ilce
    {
        public int ID { get; set; }
        
        public int IlceKey { get; set; }

        [StringLength(20), Column(TypeName = "Varchar")]
        public string Title { get; set; }
        public ICollection<Mahalle> Mahalle { get; set; }
        public Sehir Sehir { get; set; }
        [ForeignKey("Sehir")]
        public int SehirKeyIlceKey { get; set; }
   
    }
}
