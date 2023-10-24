using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
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
            var degerler=c.Carilers.FirstOrDefault(x=> x.CariMail==mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Carilers.Where(x=> x.CariMail==mail.ToString()).Select(y=> y.Cariid).FirstOrDefault();
            var degerler=c.SatisHarekets.Where(x=> x.Cariid==id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.Mesajlars.Where(x=> x.Alici==mail).ToList();
            var gelenmesaj=c.Mesajlars.Count(x=> x.Alici==mail).ToString();
            ViewBag.d1 = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.d2 = gidenmesaj;
            return View(deger);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.Mesajlars.Where(x => x.Gonderen == mail).ToList();
            var gelenmesaj = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.d2 = gidenmesaj;
            return View(deger);
        }


        //[HttpGet]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}
