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
    }
}
