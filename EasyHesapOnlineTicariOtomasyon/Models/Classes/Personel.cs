using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Personel
    {
        [Key]
        public int Personelid { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string PersonelResim { get; set; }
        public SatisHareket SatisHareket { get; set; }
        public Departman Departman { get; set; }
    }
}