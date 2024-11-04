using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class XeController : Controller
    {
        // GET: Xe
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Xe> dsXe = db.Xes.ToList();
            return View(dsXe);
        }
    }
}