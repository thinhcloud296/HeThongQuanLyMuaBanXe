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
            List<Xe> allProducts = db.Xes.ToList();
            ViewBag.AllProducts = allProducts;
            return View();
        }
        public ActionResult ChiTietSanPham(int? id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Xe xeChiTiet = db.Xes.FirstOrDefault(x => x.MaXe == id);
            if (xeChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(xeChiTiet);
        }
    }
}