using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("Sokak")]
    public class Sokak
    {
        public int ID { get; set; }
        public int? SokakKey { get; set; }
        [StringLength(150), Column(TypeName = "Varchar")]
        public string Title { get; set; }
        public Mahalle Mahalle { get; set; }
        [ForeignKey("Mahalle")]   
        public int? MahalleKeySokakKey { get; set; }


    }
}
