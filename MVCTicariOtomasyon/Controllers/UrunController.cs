using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTicariOtomasyon.Models.Siniflar;
namespace MVCTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(z=>z.Durum==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                      select new SelectListItem
                                      {
                                          Text = x.KategoriAdi,
                                          Value = x.KategoriId.ToString()

                                      }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult URUNSil(int Id)
        {
            var deger = c.Uruns.Find(Id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int Id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.KategoriId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var Urundeger = c.Uruns.Find(Id);
            return View("UrunGetir",Urundeger);
        }
        public ActionResult UrunGuncelle(Urun a )
        {
            var urn = c.Uruns.Find(a.UrunId);
            urn.AlisFiyat = a.AlisFiyat;
            urn.SatisFiyat = a.SatisFiyat;
            urn.Durum = a.Durum;
            urn.KategoriId = a.KategoriId;
            urn.Marka = a.Marka;
            urn.SatisFiyat = a.SatisFiyat;
            urn.Stok = a.Stok;
            urn.UrunAd = a.UrunAd;
            urn.UrunGorsel = a.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}