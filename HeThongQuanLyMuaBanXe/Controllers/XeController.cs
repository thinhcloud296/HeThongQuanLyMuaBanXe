using HeThongQuanLyMuaBanXe.Filter;
using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class XeController : Controller
    {
        // GET: Xe
        public ActionResult Index(string search="",string dongXe = null, List<string> mauXe = null,int trang = 1)
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Xe> allProducts = db.Xes.ToList();
            // Search
            allProducts = db.Xes.Where(row=>row.TenXe.Contains(search)).ToList();
            ViewBag.Search = search;
            // Lọc
            List<string> colors = db.Xes.Select(x => x.MauSac).Distinct().ToList();
            ViewBag.ColorsOfProduct = colors ?? new List<string>();
            List<string> dongXes = db.Xes.Select(x => x.DongXe).Distinct().ToList();
            ViewBag.CacDongXe = dongXes ?? new List<string>();
            if (!string.IsNullOrEmpty(dongXe))
            {
                allProducts = allProducts.Where(row => row.DongXe == dongXe).ToList();
            }
            if (mauXe != null && mauXe.Any())
            {
                allProducts = allProducts.Where(row => mauXe.Contains(row.MauSac)).ToList();
            }
            // Phân trang
            int NoOfRecordPerPage = 8; 
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(allProducts.Count) / NoOfRecordPerPage));
            int NoOfRecordToSkip = (trang - 1) * NoOfRecordPerPage;
            ViewBag.Trang = trang;
            ViewBag.NoOfPages = NoOfPages;
            allProducts = allProducts.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
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
        [AuthFilter]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Xe xe)
        {
            if (ModelState.IsValid)
            {
                CompanyDbContext db = new CompanyDbContext();
                db.Xes.Add(xe);
                db.SaveChanges();
                return RedirectToAction("Index", "NhanVien");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Xe nvCheck = db.Xes.Where(x => x.MaXe == id).FirstOrDefault();
            return View(nvCheck);
        }
        [HttpPost]
        public ActionResult Delete(int id, Xe _)
        {
            CompanyDbContext db = new CompanyDbContext();
            Xe nvCheck = db.Xes.Where(x => x.MaXe == id).FirstOrDefault();
            db.Xes.Remove(nvCheck);
            db.SaveChanges();
            return RedirectToAction("QuanLyKhoXe", "NhanVien");
        }
        public ActionResult Edit(int id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Xe nvCheck = db.Xes.Where(x => x.MaXe == id).FirstOrDefault();
            return View(nvCheck);
        }
        [HttpPost]
        public ActionResult Edit(Xe nv)
        {
            CompanyDbContext db = new CompanyDbContext();
            ViewBag.EditCheck = "";
            Xe nvCheck = db.Xes.Where(x => x.MaXe == nv.MaXe).FirstOrDefault();
            if (nvCheck != null)
            {
                nvCheck.TenXe = nv.TenXe;
                nvCheck.HangXe = nv.HangXe;
                nvCheck.DongXe = nv.DongXe;
                nvCheck.SoKhungXe = nv.SoKhungXe;
                nvCheck.MauSac = nv.MauSac;
                nvCheck.NamSanXuat = nv.NamSanXuat;
                nvCheck.GiaBanXe = nv.GiaBanXe;
                db.SaveChanges();
                return RedirectToAction("QuanLyKhoXe", "NhanVien");
            }
            ViewBag.EditCheck = "Chỉnh sửa không thành công !";
            return RedirectToAction("QuanLyKhoXe", "NhanVien");
        }
    }
}