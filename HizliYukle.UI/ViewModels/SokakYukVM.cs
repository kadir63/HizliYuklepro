using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HizliYukle.UI.ViewModels
{
    public class SokakYukVM
    {
        public ICollection<YukBilgi> YukBilgi { get; set; }
        public ICollection<Sokak> Sokak { get; set; }
    }
}