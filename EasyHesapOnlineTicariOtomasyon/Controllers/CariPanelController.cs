using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Schema;
using EasyHesapOnlineTicariOtomasyon.Models.Classes;
using Context = EasyHesapOnlineTicariOtomasyon.Models.Classes.Context;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {


        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler=c.Carilers.Where(x=> x.CariMail==mail).ToList();
            ViewBag.m = mail;
            var mailid=c.Carilers.Where(x=> x.CariMail==mail).Select(y=>y.Cariid).FirstOrDefault();
            ViewBag.mid=mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.Cariid == mailid).Count();
            ViewBag.toplamsatis=toplamsatis;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Carilers.Where(x=> x.CariMail==mail.ToString()).Select(y=> y.Cariid).FirstOrDefault();
            var degerler=c.SatisHarekets.Where(x=> x.Cariid==id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.Mesajlars.Where(x=> x.Alici==mail).OrderByDescending(x=> x.Mesajid).ToList();
            var gelenmesaj=c.Mesajlars.Count(x=> x.Alici==mail).ToString();
            ViewBag.d1 = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.d2 = gidenmesaj;
            return View(deger);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.Mesajlars.Where(x => x.Gonderen == mail).OrderByDescending(x => x.Mesajid).ToList();
            var gelenmesaj = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.d2 = gidenmesaj;
            return View(deger);
        }
        [Authorize]

        public ActionResult MesajDetay(int id)
        {
            var deger=c.Mesajlars.Where(x=> x.Mesajid==id).ToList();
            var mail = (string)Session["CariMail"];
            var gelenmesaj = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.d2 = gidenmesaj;
            return View(deger);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesaj = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.d2 = gidenmesaj;

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Gonderen = mail;
            m.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var deger = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(deger);
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}
