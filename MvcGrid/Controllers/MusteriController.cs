using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class MusteriController : Controller
    {
        NorthwindDB db = new NorthwindDB();
        // GET: Musteri
        public ActionResult Index()
        {
            dynamic mmodel = new ExpandoObject();
            mmodel = (from m in db.Musterilers
                              join s in db.Satislars on
                              m.MusteriID equals s.MusteriID
                              select new
                              {
                                  m.MusteriID,
                                  SatisMusteriID=s.MusteriID,
                                  m.MusteriAdi,
                                  m.SirketAdi,
                                  m.Ulke,
                                  s.OdemeTarihi,
                                  s.SatisTarihi,
                                  s.SevkAdi,
                                  s.SevkAdresi
                              }).ToList();
            return View(mmodel);
        }
        public ActionResult Satis()
        {
           
            
            return View(db.Satislars.ToList());
        }
    }
}