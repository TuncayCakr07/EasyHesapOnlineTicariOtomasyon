using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Kategori
    {
        [Key]
        public int Kategoriid { get; set; }
        public string KategoriAd { get; set; }

        public ICollection<Urun> Uruns { get; set; }
    }
}