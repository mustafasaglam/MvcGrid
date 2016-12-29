using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class HomeController : Controller
    {
        NorthwindDB db = new NorthwindDB();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Musterilers.ToList());
        }
        public ActionResult PersonelSatis()
        {

            var ps = (from p in db.Personellers
                     join s in db.Satislars on 
                     p.PersonelID equals s.PersonelID
                     select new
                     {
                         p.Adi,
                         p.SoyAdi,
                         p.Unvan,
                         s.NakliyeUcreti,
                         s.SatisID,
                         s.SatisTarihi
                         
                     }).ToList();
           

            return View(ps);
        }
    }


}