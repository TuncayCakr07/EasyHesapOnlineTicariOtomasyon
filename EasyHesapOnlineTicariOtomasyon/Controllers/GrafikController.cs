using EasyHesapOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EasyHesapOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        Context c=new Context();
        private object snf;

        public ActionResult Index2()
        {
            ArrayList xvalue=new ArrayList();
            ArrayList yvalue=new ArrayList();
            var sonuclar=c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stok Grafiği").AddSeries(chartType: "Pie", name: "Ürün-Stok Grafiği", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");

        }

        public ActionResult Index4()
        {
            return View();
        }

       public ActionResult VisualizeUrunResult()
        {
          return Json(UrunListesi(),JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> UrunListesi() 
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
             {
                Urunad = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new Sinif1()
            {
                Urunad = "Beyaz Eşya",
                Stok = 150
            });
            snf.Add(new Sinif1()
            {
                Urunad = "Mobilya",
                Stok = 80
            });
            snf.Add(new Sinif1()
            {
                Urunad = "Küçük Ev Aletleri",
                Stok = 120
            });
            snf.Add(new Sinif1()
            {
                Urunad = "Mobil Cihazlar",
                Stok = 180
            });

            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(),JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> snf= new List<Sinif2>();
            using (var context=new Context())
            {
                snf=c.Uruns.Select(x=> new Sinif2
                {
                    urn=x.UrunAd,
                    stk=x.Stok,
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}