using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Fatura
    {
        [Key]
        public int Faturaid { get; set; }
        public string FaturaSerino { get; set; }
        public string FaturaSirano { get; set; }
        public DateTime Tarih { get; set; }
        public string VergiDairesi { get; set;}
        public DateTime Saat { get; set; }
        public string TeslimEden { get; set; }
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}