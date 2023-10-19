using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c=new Context();
        public ActionResult Index()
        {
            var deger=c.Personels.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.Departmanid.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti; 
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelResim = "/Images/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.Departmanid.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs=c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel p, HttpPostedFileBase YeniPersonelResim)
        {
            var prsn = c.Personels.FirstOrDefault(x => x.Personelid == p.Personelid);
            if (prsn != null)
            {
                prsn.PersonelAd = p.PersonelAd;
                prsn.PersonelSoyad = p.PersonelSoyad;
                prsn.Departmanid = p.Departmanid;

                if (YeniPersonelResim != null && YeniPersonelResim.ContentLength > 0)
                {
                    string dosyaadi = Path.GetFileName(YeniPersonelResim.FileName);
                    string uzanti = Path.GetExtension(YeniPersonelResim.FileName);
                    string yol = "~/Images/" + dosyaadi + uzanti;
                    YeniPersonelResim.SaveAs(Server.MapPath(yol));
                    prsn.PersonelResim = "/Images/" + dosyaadi + uzanti;
                }

                c.Entry(prsn).State = EntityState.Modified;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            if (personel != null)
            {
                c.Personels.Remove(personel);
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult PersonelList()
        {
            var deger=c.Personels.ToList();
            return View(deger);
        }
    }
}