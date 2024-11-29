using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class DichVuController : Controller
    {
        // GET: DichVu
        public ActionResult Index(int trang = 1)
        {
            CompanyDbContext db = new CompanyDbContext();
            List<ThongTinDichVu> allDichVus = db.ThongTinDichVus.ToList();

           
            return View(allDichVus);
        }

        public ActionResult ChiTietDichVu(string id) 
        {
            if (id == null)
            {
                return HttpNotFound(); 
            }

            CompanyDbContext db = new CompanyDbContext();

            var dichVu = db.ThongTinDichVus.FirstOrDefault(d => d.MaDichVu == id); 

            if (dichVu == null)
            {
                return HttpNotFound(); 
            }

            return View(dichVu);
        }
    }
}