using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("Mahalle")]
    public class Mahalle
    {
        public int ID { get; set; }
       
        public int? MahalleKey { get; set; }

        [StringLength(50), Column(TypeName = "Varchar")]
        public string Title { get; set; }
        public ICollection<Sokak> Sokak { get; set; }
        public Ilce Ilce { get; set; }
        [ForeignKey("Ilce")]
        public int IlceKeyMahalleKey { get; set; }
    }

}
