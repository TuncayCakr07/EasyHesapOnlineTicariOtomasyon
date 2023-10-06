using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;
namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value=x.Kategoriid.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun y)
        {
            c.Uruns.Add(y);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.Kategoriid.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger=c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }

        public ActionResult UrunGuncelle(Urun t)
        {
            var urn = c.Uruns.Find(t.Urunid);
            urn.AlisFiyati = t.AlisFiyati;
            urn.Durum = t.Durum;
            urn.Kategoriid=t.Kategoriid;
            urn.MarkaAdi = t.MarkaAdi;
            urn.SatisFiyati=t.SatisFiyati;
            urn.Stok=t.Stok;
            urn.UrunAd=t.UrunAd;
            urn.UrunResim=t.UrunResim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}