using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Urun
    {
        [Key]
        public int Urunid { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(50)]
        public string UrunAd { get; set; }
        
        
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MarkaAdi { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunResim { get; set; }
        public Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}