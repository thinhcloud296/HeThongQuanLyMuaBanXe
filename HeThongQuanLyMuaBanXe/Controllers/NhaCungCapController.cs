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
        
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<NhaCungCap> allNhaCungCaps = db.NhaCungCaps.ToList();


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