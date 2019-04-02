using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("YukBilgi")]
    public class YukBilgi
    {
        public int ID { get; set; }
        [StringLength(250), Column(TypeName = "varchar")]
        public string Aciklama { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string YuklemeSehri { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string YuklemeIlce { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string BosaltmaSehri { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string BosaltmaIlce { get; set; }
       
        public string YukuYuklemeTarih { get; set; }
        public int? YukVerenID { get; set; }
        public YukVeren YukVeren { get; set; }
    }
}
