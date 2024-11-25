using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NhanVien nv)
        {
            if (nv != null)
            {
                CompanyDbContext db = new CompanyDbContext();
                NhanVien nvCheck = db.NhanViens.Where(nvien => nvien.TenDangNhap == nv.TenDangNhap).FirstOrDefault();
                if (nvCheck != null)
                {
                    if (nvCheck.MatKhau == nv.MatKhau)
                    {
                        HttpCookie authCookie = new HttpCookie("auth", nvCheck.TenDangNhap);
                        HttpCookie nameCookie = new HttpCookie("name", HttpUtility.UrlEncode(nvCheck.TenNhanVien, System.Text.Encoding.UTF8));
                        Response.Cookies.Add(nameCookie);
                        HttpCookie roleCookie = new HttpCookie("role", nvCheck.ChucVuNhanVien);
                        Response.Cookies.Add(authCookie);
                        Response.Cookies.Add(nameCookie);
                        Response.Cookies.Add(roleCookie);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            //ModelState.AddModelError("MatKhau", "Đăng nhập không thành công !");
            return View();
        }
        public ActionResult Logout()
        {
            HttpCookie authCookie = new HttpCookie("auth");
            HttpCookie nameCookie = new HttpCookie("name");
            Response.Cookies.Add(nameCookie);
            HttpCookie roleCookie = new HttpCookie("role");

            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);

            nameCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(nameCookie);

            roleCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(nameCookie);

            return Redirect("/");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(NhanVien nv)
        {
            if (nv != null)
            {
                CompanyDbContext db = new CompanyDbContext();
                NhanVien nvCheck = db.NhanViens.Where(nvien => nvien.TenDangNhap == nv.TenDangNhap).FirstOrDefault();
                if (nvCheck == null)
                {
                    if (nv.ChucVuNhanVien.Equals("Quản lý"))
                        nv.VaiTro = "admin";
                    else
                        nv.VaiTro = "user";
                    nv.MaNhanVien = TaoMaNV();
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
            }
            return View();
        }
        public string TaoMaNV()
        {
            CompanyDbContext db = new CompanyDbContext();
            int soNVHienTai = db.NhanViens.ToList().Count;
            soNVHienTai++;
            return "NV" + soNVHienTai.ToString("D3");
        }
    }
}