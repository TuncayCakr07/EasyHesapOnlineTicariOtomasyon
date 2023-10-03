using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Cariler
    {
        [Key] 
        public int Cariid { get; set; }
        public string CariAd { get; set; }
        public string CariSoyad { get; set; }
        public string CariUnvan { get; set; }
        public string CariSehir { get; set; }
        public string CariMail { get; set; }
        public string CariTelefon { get; set; }
        public string CariAdres { get; set; }
        public SatisHareket SatisHareket { get; set; }

    }
}