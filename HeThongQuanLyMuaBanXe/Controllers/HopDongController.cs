using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class HopDongController : Controller
    {
        // GET: HopDong
        public ActionResult Index(int MaXe)
        {
            CompanyDbContext db = new CompanyDbContext();
            // Lấy thông tin xe từ cơ sở dữ liệu nếu cần
            Xe xe = db.Xes.FirstOrDefault(x => x.MaXe == MaXe);
            decimal giaBanXe = xe?.GiaBanXe ?? 0;
            // Tính thuế VAT (10% giá trị bán của xe)
            decimal thueVAT = giaBanXe * 0.1m;

            // Tính thuế nhập khẩu (70% giá trị bán của xe)
            decimal thueNhapKhau = giaBanXe * 0.7m;

            // Tính thuế TTĐB (60% giá trị bán của xe)
            decimal thueTTDB = giaBanXe * 0.6m;

            // Tính phí trước bạ (10% giá trị xe)
            decimal phiTruocBa = giaBanXe * 0.1m;

            // Tính tổng giá trị hợp đồng
            decimal tongGiaTriHopDong = giaBanXe + thueVAT + thueNhapKhau + thueTTDB + phiTruocBa;

            // Khởi tạo đối tượng hợp đồng
            var hopDong = new HopDongMuaBan
            {
                MaXe = MaXe,
                NgayLapHopDong = DateTime.Now,
                TongGiaTriHopDong = tongGiaTriHopDong
            };
            ViewBag.TenXe = xe?.TenXe;
            ViewBag.MauSac = xe?.MauSac;
            ViewBag.SoKhung = xe?.SoKhungXe;
            ViewBag.GiaBan = xe?.GiaBanXe;

            return View(hopDong);
        }
        [HttpPost]
        public ActionResult Create(HopDongMuaBan hd)
        {
            if(hd!=null)
            {
                CompanyDbContext db = new CompanyDbContext();
                db.HopDongMuaBans.Add(hd);
                db.SaveChanges();
            }
            return View(hd);
        }
    }
}