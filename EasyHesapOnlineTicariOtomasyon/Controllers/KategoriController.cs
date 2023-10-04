using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c=new Context();
        public ActionResult Index()
        {
            var values=c.Kategoris.ToList();
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
    }
}