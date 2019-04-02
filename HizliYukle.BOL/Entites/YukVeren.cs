using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.BOL.Entites
{   [Table("YukVeren")]
  public  class YukVeren
    {
        public int ID { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string FirmaAd { get; set; }
        [StringLength(150), Column(TypeName = "varchar")]
        public string Adres { get; set; }
        [StringLength(20), Column(TypeName = "varchar")]
        public string Telefon { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string YetkiliAd { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string YetkiliSoyad { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string Email { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string Sehir { get; set; }
        [StringLength(20), Column(TypeName = "varchar")]
        public string Ilce { get; set; }
        [StringLength(20), Column(TypeName = "varchar")]
        public string sifre { get; set; }
        [NotMapped ,StringLength(50), Column(TypeName = "varchar")]
        public string sifre2 { get; set; }
        IQueryable<YukBilgi> YukBilgi { get; set; }
        [StringLength(30), Column(TypeName = "varchar")]
        public string Rol { get; set; }
    }
}
