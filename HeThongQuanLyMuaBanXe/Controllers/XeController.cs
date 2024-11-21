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
        public ActionResult Index(string dongXe = null, List<string> mauXe = null)
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Xe> allProducts = db.Xes.ToList();
            // Lấy danh sách các màu sắc xe và các dòng xe
            List<string> colors = db.Xes.Select(x => x.MauSac).Distinct().ToList();
            ViewBag.ColorsOfProduct = colors ?? new List<string>();

            List<string> dongXes = db.Xes.Select(x => x.DongXe).Distinct().ToList();
            ViewBag.CacDongXe = dongXes ?? new List<string>();

            // Lọc theo dòng xe nếu có
            if (!string.IsNullOrEmpty(dongXe))
            {
                allProducts = allProducts.Where(row => row.DongXe == dongXe).ToList();
            }

            // Lọc theo màu sắc nếu có
            if (mauXe != null && mauXe.Any())
            {
                allProducts = allProducts.Where(row => mauXe.Contains(row.MauSac)).ToList();
            }


            return View(allProducts);
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