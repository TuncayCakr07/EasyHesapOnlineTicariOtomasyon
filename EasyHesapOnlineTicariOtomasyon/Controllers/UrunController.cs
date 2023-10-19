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
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();

        public ActionResult Index(string p, int sayfa = 1)
        {
            var urunler =from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList().ToPagedList(sayfa, 5));
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
        public ActionResult UrunListesi()
        {
            var deger=c.Uruns.ToList();
            return View(deger); 
        }
    }
}