using HeThongQuanLyMuaBanXe.Filter;
using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
         CompanyDbContext db = new CompanyDbContext();
        [AuthFilter]
        public ActionResult Index()
        {
            var role = Request.Cookies["role"].Value;
            if (role == null)
            {
                return View();
            }
            if (role == "admin")
            {
                return RedirectToAction("QuanLyNhanVien");
            }
            if (role == "userDonHang")
            {
                return RedirectToAction("QuanLyDonHang");
            }
            return View();
        }
        public ActionResult QuanLyDonHang()
        {
            var hopDongList = db.HopDongMuaBans.ToList();
            var khachHangList = db.KhachHangs.ToList();
            ViewBag.HopDongList = hopDongList;
            ViewBag.KhachHangList = khachHangList;
            return View(hopDongList); 
        }
        [HttpPost]
        public ActionResult ChangeStatus(string maHopDong, string newStatus)
        {
            var hopDong = db.HopDongMuaBans.SingleOrDefault(h => h.MaHopDong.ToString() == maHopDong);
            if (hopDong != null)
            {
                hopDong.TrangThaiHopDong = newStatus;
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        public ActionResult QuanLyNhanVien()
        {
            List<NhanVien> dsNV = db.NhanViens.ToList();
            return View(dsNV);
        }
    }
}