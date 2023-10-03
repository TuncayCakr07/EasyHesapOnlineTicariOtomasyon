using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemid { get; set; }
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal Birimfiyat { get; set; }
        public decimal Tutar { get; set; }
        public FaturaKalem Faturalar { get; set; }
    }
}