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
        CompanyDbContext db = new CompanyDbContext();
        public ActionResult Index(string HangXe = "Lamborghini", string DongXe = "Hypercar")
        {  
            List<Xe> dsXeTheoHang = db.Xes.Where(x => x.HangXe == HangXe).Take(4).ToList();
            ViewBag.dsXeTheoHang = dsXeTheoHang;
            List<Xe> dsXeTheoDong = db.Xes.Where(x => x.DongXe == DongXe).Take(4).ToList();
            ViewBag.dsXeTheoDong = dsXeTheoDong;
            return View();
        }
    }
}