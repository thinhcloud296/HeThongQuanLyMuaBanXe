using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyMuaBanXe.Models;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Xe> dsXe = db.Xes.ToList();
            return View(dsXe);
        }
    }
}