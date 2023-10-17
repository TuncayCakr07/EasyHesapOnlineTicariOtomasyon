using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c=new Context();
        public ActionResult Index()
        {
            var deger1=c.Carilers.Count().ToString();
            ViewBag.deger1=deger1;
            var deger2=c.Uruns.Count().ToString();
            ViewBag.deger2=deger2;
            var deger3=c.Kategoris.Count().ToString();  
            ViewBag.deger3=deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.deger4=deger4;

            var yapilacak=c.Yapilacaklar.ToList();
            return View(yapilacak);
        }
    }
}