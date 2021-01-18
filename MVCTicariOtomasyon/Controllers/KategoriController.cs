using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTicariOtomasyon.Models.Siniflar;
namespace MVCTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();

            return View(degerler);
        }
        [HttpGet] // yüklendiğinde
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost] // Tıklandıgında
        public ActionResult KategoriEkle( Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);

        }

        public ActionResult KategoriGüncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriId);
            kategori.KategoriAdi = k.KategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}