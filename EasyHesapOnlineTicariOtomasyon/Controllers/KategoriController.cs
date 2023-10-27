using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c=new Context();
        public ActionResult Index(int sayfa=1)
        {
            var values = c.Kategoris.ToList().ToPagedList(sayfa, 5);
            return View(values);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            TempData["KategoriKaydetMesaj"] = "Kategori başarıyla kaydedildi.";
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg=c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg= c.Kategoris.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.Kategoriid);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriUrun()
        {
            Class3 cs=new Class3();
            cs.Kategoriler = new SelectList(c.Kategoris, "Kategoriid", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "Urunid", "UrunAd");
            return View(cs);    
        }

        public JsonResult UrunGetir(int p)
        {
            var urunler = (from x in c.Uruns
                           join y in c.Kategoris
                           on x.Kategori.Kategoriid equals y.Kategoriid
                           where x.Kategori.Kategoriid == p
                           select new
                           {
                               Text = x.UrunAd,
                               Value = x.Urunid.ToString()
                           }).ToList();
            return Json(urunler,JsonRequestBehavior.AllowGet);   
        }
    }
}