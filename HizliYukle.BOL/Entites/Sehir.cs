using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("Sehir")]
    public class Sehir
    {
        public int ID { get; set; }
        public int SehirKey { get; set; }

        [StringLength(20), Column(TypeName = "Varchar")]
        public string Title { get; set; }
        public ICollection<Ilce> Ilce { get; set; }
    }
}
