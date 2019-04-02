using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{
    [Table("Nakliyeci")]
    public  class Nakliyeci
    {
        public int ID  { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string Ad  { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string Soyad  { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string VergiDairesi  { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string VergiNo  { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string sifre { get; set; }
        [NotMapped, StringLength(50), Column(TypeName = "varchar")]
        public string sifre2 { get; set; }

        public virtual AracBilgi AracBilgi { get; set; }
        [StringLength(12), Column(TypeName = "varchar")]
        public string Tel  { get; set; }
    }
}
