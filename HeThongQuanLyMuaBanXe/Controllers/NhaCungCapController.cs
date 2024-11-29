using HeThongQuanLyMuaBanXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        public ActionResult Index(string search = "", int trang = 1)
        {
            CompanyDbContext db = new CompanyDbContext();
            var allNhaCungCaps = db.NhaCungCaps.Where(n => n.TenNhaCungCap.Contains(search)).ToList();

            int NoOfRecordPerPage = 6; 
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(allNhaCungCaps.Count) / NoOfRecordPerPage));
            int NoOfRecordToSkip = (trang - 1) * NoOfRecordPerPage;

            ViewBag.Trang = trang;
            ViewBag.NoOfPages = NoOfPages;

            allNhaCungCaps = allNhaCungCaps.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(allNhaCungCaps);
        }

        public ActionResult ChiTietNhaCungCap(string id)
        {
            if (id == null)
            {
                return HttpNotFound(); 
            }

            CompanyDbContext db = new CompanyDbContext();

            var nhaCungCap = db.NhaCungCaps.FirstOrDefault(d => d.MaNhaCungCap == id); 

            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }

            return View(nhaCungCap); 
        }
    }
}
