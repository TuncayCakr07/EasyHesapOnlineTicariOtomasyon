using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Urun
    {
        [Key]
        public int Urunid { get; set; }
        public string UrunAd { get; set; }
        public string MarkaAdi { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        public string UrunResim { get; set; }
        public Kategori Kategori { get; set; }
        public SatisHareket SatisHareket { get; set; }

    }
}