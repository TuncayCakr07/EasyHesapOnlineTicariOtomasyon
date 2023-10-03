using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHesapOnlineTicariOtomasyon.Models.Classes
{
    public class Departman
    {
        [Key]
        public int Departmanid { get; set; } 
        public string DepartmanAdi { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}