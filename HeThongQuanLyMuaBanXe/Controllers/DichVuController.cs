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
        public ActionResult Index(string search = "", int trang = 1)
        {
            CompanyDbContext db = new CompanyDbContext();

            var dichVus = db.ThongTinDichVus.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                dichVus = dichVus.Where(d => d.TenDichVu.Contains(search));
            }
            int pageSize = 6;
            int pageNumber = trang;
            int totalItems = dichVus.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var pagedDichVus = dichVus.OrderBy(d => d.TenDichVu)
                                       .Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();

            ViewBag.SearchTerm = search;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = trang;

            return View(pagedDichVus);
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
