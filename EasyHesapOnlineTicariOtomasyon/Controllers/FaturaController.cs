using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c=new Context();
        public ActionResult Index()
        {
            var liste=c.Faturas.ToList();
            return View(liste);
        }
        [HttpGet] 
        public ActionResult FaturaEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            f.Toplam = 0.0m;
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura=c.Faturas.Find(id);
            return View("FaturaGetir",fatura);
        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = c.Faturas.Find(f.Faturaid);
            fatura.FaturaSerino = f.FaturaSerino;
            fatura.FaturaSirano = f.FaturaSirano;
            fatura.Saat=f.Saat;
            fatura.Tarih=f.Tarih;
            fatura.TeslimEden=f.TeslimEden;
            fatura.TeslimAlan=f.TeslimAlan;
            fatura.VergiDairesi=f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            var ftr = c.Faturas.Where(x => x.Faturaid == id).Select(y=> y.FaturaSirano).FirstOrDefault();
            ViewBag.ftr = ftr;
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem k)
        {
            c.FaturaKalems.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs=new Class4();
            cs.deger1=c.Faturas.ToList();
            cs.deger2=c.FaturaKalems.ToList();
            return View(cs);
        }
    }
}