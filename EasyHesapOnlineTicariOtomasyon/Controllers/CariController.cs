using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c=new Context();    
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=> x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari() 
        {
            return View();        
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cr = c.Carilers.Find(id);
            return View("CariGetir", cr);
        }
        
        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid) 
            {
              return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.Cariid);
            cari.CariAd=p.CariAd;
            cari.CariSoyad=p.CariSoyad;
            cari.CariUnvan=p.CariUnvan;
            cari.CariSehir=p.CariSehir;
            cari.CariMail=p.CariMail;
            cari.CariTelefon=p.CariTelefon;
            cari.CariAdres=p.CariAdres;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var deger=c.SatisHarekets.Where(x=> x.Cariid==id).ToList();
            var dgr = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.dgr= dgr;
            return View(deger);
        }
    }
}