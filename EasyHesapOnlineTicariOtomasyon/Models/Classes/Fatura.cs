using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Fatura
    {
        [Key]
        public int Faturaid { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSerino { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSirano { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set;}

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Saat { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimEden { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}