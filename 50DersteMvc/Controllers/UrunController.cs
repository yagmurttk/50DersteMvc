using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMvc.Models.Entity;

namespace _50DersteMvc.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIADI,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBL_URUNLER p1)
        {
            var ktg = db.TBL_KATEGORILER.Where(m => m.KATEGORIID == p1.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBL_KATEGORILER = ktg;
            db.TBL_URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}