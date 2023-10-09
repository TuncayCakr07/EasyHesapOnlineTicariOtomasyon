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
        [StringLength(50,ErrorMessage ="En Fazla 50 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        [Required(ErrorMessage ="Bu Alanı Boş Geçemezsiniz!")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        public string CariUnvan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En Fazla 20 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        public string CariTelefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En Fazla 250 Karakter Girilebilir ! Lütfen Düzeltiniz!")]
        public string CariAdres { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}