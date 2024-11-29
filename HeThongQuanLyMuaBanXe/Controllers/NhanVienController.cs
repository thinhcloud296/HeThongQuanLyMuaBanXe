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
                return RedirectToAction("Login", "User");
            }
            if (role == "admin")
            {
                return RedirectToAction("QuanLyNhanVien");
            }
            if (role == "userDonHang")
            {
                return RedirectToAction("QuanLyDonHang");
            }
            if (role == "userKho")
            {
                return RedirectToAction("QuanLyKhoXe");
            }
            return RedirectToAction("Login", "User");
        }
        [AuthFilter]
        public ActionResult QuanLyDonHang()
        {
            var hopDongList = db.HopDongMuaBans.ToList();
            ViewBag.HopDongList = hopDongList;
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
        [AuthFilter]
        public ActionResult QuanLyNhanVien()
        {
            List<NhanVien> dsNV = db.NhanViens.ToList();
            return View(dsNV);
        }
        public ActionResult DeleteNV(string id)
        {
            NhanVien nvCheck = db.NhanViens.Where(x => x.MaNhanVien == id).FirstOrDefault();
            return View(nvCheck);
        }
        [HttpPost]
        public ActionResult DeleteNV(string id, NhanVien _)
        {
            NhanVien nvCheck = db.NhanViens.Where(x => x.MaNhanVien == id).FirstOrDefault();
            db.NhanViens.Remove(nvCheck);
            db.SaveChanges();
            return RedirectToAction("QuanLyNhanVien","NhanVien");
        }
        public ActionResult EditNV(string id)
        {
            NhanVien nvCheck = db.NhanViens.Where(x => x.MaNhanVien == id).FirstOrDefault();
            return View(nvCheck);
        }
        [HttpPost]
        public ActionResult EditNV(NhanVien nv)
        {
            ViewBag.EditCheck = "";
            NhanVien nvCheck = db.NhanViens.Where(x => x.MaNhanVien == nv.MaNhanVien).FirstOrDefault();
            if (nvCheck != null)
            {
                nvCheck.TenNhanVien = nv.TenNhanVien;
                nvCheck.DiaChiNhanVien = nv.DiaChiNhanVien;
                nvCheck.SoDienThoaiNhanVien = nv.DiaChiNhanVien;
                nvCheck.EmailNhanVien=nv.EmailNhanVien;
                nvCheck.TenDangNhap=nv.TenDangNhap;
                nvCheck.MatKhau=nv.MatKhau;
                nvCheck.VaiTro=nv.VaiTro;
                db.SaveChanges();
                return RedirectToAction("QuanLyNhanVien", "NhanVien");
            }
            ViewBag.EditCheck = "Chỉnh sửa không thành công !";
            return RedirectToAction("QuanLyNhanVien", "NhanVien");
        }
        [AuthFilter]
        public ActionResult QuanLyKhoXe()
        {
            List<Xe> dsXe = db.Xes.ToList();
            return View(dsXe);
        }
    }
}