using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTicariOtomasyon.Models.Siniflar;  //İLK EKLENEN

namespace MVCTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context(); // 2.ci eklenen

        public ActionResult Index() //  5 ADD View 
        {
            var deger = c.Deparmen.Where(z => z.Durum == true).ToList(); // 3
            return View(deger); // 4 
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Deparman d)
        {
           var de= c.Deparmen.Add(d);
            de.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Deparmen.Find(id);
            dep.Durum = false;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Deparmen.Find(id);
            return View("DepartmanGetir", dpt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGüncelle(Deparman d)
        {
            var dpt = c.Deparmen.Find(d.DepartmanId);
            dpt.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Deparmen.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.de = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatıs(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var PER = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = PER;
            return View();
        }
    }
}