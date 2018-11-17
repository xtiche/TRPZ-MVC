using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2HW.Models;

namespace Lab2HW.Controllers
{
    public class HomeWorkController : Controller
    {
        private Lab2HWDBEntities2 db = new Lab2HWDBEntities2();
        // GET: HomeWork
        public ActionResult Index()
        {
            var shop = (from Type_Shop in db.Type_Shop
                        join Shop in db.Shops on Type_Shop.IdShop equals Shop.IdShop
                        join Type in db.Types on Type_Shop.IdType equals Type.IdType
                        where Type.Name == "Supermarket"
                        select new TypeShop
                        {
                            IdShop = Shop.IdShop,
                            IdType = Type.IdType,
                            ShopName = Shop.Name,
                            TypeName = Type.Name
                        }
                       ).ToList();

            return View(shop);
        }


        [HttpGet]
        public ActionResult Create()
        {
            Shop newShop = new Shop();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shop newShop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Shops.Add(newShop);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("SelectShopType", new { shopid = newShop.IdShop });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
            }
            return View(newShop);
        }
        [HttpGet]
        public ActionResult SelectShopType(int shopid)
        {
            Type_Shop ts = new Type_Shop
            {
                IdShop = shopid,
                IdType = 1
            };
            return View(ts);
        }
        [HttpPost]
        public ActionResult SelectShopType(Type_Shop ts)
        {
            try
            {
                db.Type_Shop.Add(ts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
            }
            return View(ts);
        }
        [HttpGet]
        public ActionResult EditShop(int id)
        {
            var shopEdit = (from newShop in db.Shops
                        where newShop.IdShop == id
                        select newShop).First();
            return View(shopEdit);
        }
        [HttpPost]
        public ActionResult EditShop(int id, FormCollection collection)
        {
            var shopEdit = (from newShop in db.Shops
                            where newShop.IdShop == id
                            select newShop).First();
            try
            {
                UpdateModel(shopEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(shopEdit);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var shopDelete = (from s in db.Shops
                              where s.IdShop == id
                              select s).First();
            return View(shopDelete);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var shopDelete = (from Shop in db.Shops
                              where Shop.IdShop == id
                              select Shop).First();
            try
            {
                db.Shops.Remove(shopDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(shopDelete);
            }
        }

    }
}
