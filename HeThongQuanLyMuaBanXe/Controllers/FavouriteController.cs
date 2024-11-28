using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyMuaBanXe.Models;
namespace HeThongQuanLyMuaBanXe.Controllers
{
    public class FavouriteController : Controller
    {
        // GET: Favourite
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Favourite> favourites = db.Favourites.ToList();
            return View(favourites);
        }
        public ActionResult Add(int id = 0)
        {
            if (id > 0)
            {
                CompanyDbContext db = new CompanyDbContext();
                Favourite favourItem = db.Favourites.Where(cart => cart.MaXe == id).FirstOrDefault();
                if (favourItem != null)
                {
                    favourItem.SoLuong += 1;
                }
                else
                {
                    Favourite cart = new Favourite();
                    cart.MaXe = id;
                    cart.SoLuong = 1;
                    db.Favourites.Add(cart);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int quan = 0, int proid = 0)
        {
            CompanyDbContext db = new CompanyDbContext();
            if (quan > 0)
            {
                Favourite favourItem = db.Favourites.Where(cart => cart.MaXe == proid).FirstOrDefault();
                if (favourItem != null)
                {
                    favourItem.SoLuong = quan;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            CompanyDbContext db = new CompanyDbContext();
            if (id > 0)
            {
                Favourite favourItem = db.Favourites.Where(cart => cart.MaXe == id).FirstOrDefault();
                if (favourItem != null)
                {
                    db.Favourites.Remove(favourItem);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}