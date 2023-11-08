using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMvc.Models.Entity;


namespace _50DersteMvc.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_MUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_MUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
            db.TBL_MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_MUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBL_MUSTERILER p1)
        {
            var mus = db.TBL_MUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}