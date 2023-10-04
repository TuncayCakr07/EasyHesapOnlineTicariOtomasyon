using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Cariler
    {
        [Key] 
        public int Cariid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariUnvan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariTelefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string CariAdres { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}