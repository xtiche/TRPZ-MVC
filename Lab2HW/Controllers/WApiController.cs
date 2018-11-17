using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Web.Http;
using Lab2HW.Models;
namespace Lab2HW.Controllers
{
    public class WApiController : ApiController
    {
        Lab2HWDBEntities2 db = new Lab2HWDBEntities2();


        [HttpGet]
        [ActionName("GetShops")]
        public ICollection<Shop> GetShops()
        {
            var ts = (from s in db.Shops select s).ToList();

            Collection<Shop> TS = new Collection<Shop>();

            foreach (Shop item in ts)
                TS.Add(new Shop
                {
                    IdShop = item.IdShop,
                    Name = item.Name
                });

            return TS;
        }

        [HttpGet]
        [ActionName("GetShops")]
        public ICollection<Shop> GetShops(int id)
        {
            var ts = (from s in db.Shops where s.IdShop == id select s).ToList();

            Collection<Shop> TS = new Collection<Shop>();

            foreach (Shop item in ts)
                TS.Add(new Shop
                {
                    IdShop = item.IdShop,
                    Name = item.Name
                });

            return TS;
        }

        [HttpGet]
        [ActionName("GetTypeShops")]
        public ICollection<TypeShop> GetTypeShops()
        {
            var ts = (from typs in db.Type_Shop
                      join s in db.Shops on typs.IdShop equals s.IdShop
                      join t in db.Types on typs.IdType equals t.IdType
                      select new TypeShop
                      {
                          IdShop = s.IdShop,
                          ShopName = s.Name,
                          IdType = t.IdType,
                          TypeName = t.Name
                      }).ToList();

            Collection<TypeShop> TS = new Collection<TypeShop>();

            foreach (TypeShop item in ts)
                TS.Add(new TypeShop
                {
                    IdShop = item.IdShop,
                    ShopName = item.ShopName,
                    IdType = item.IdType,
                    TypeName = item.TypeName
                });

            return TS;
        }

        [HttpPost]
        [ActionName("CreateShop")]
        public HttpResponseMessage CreateShop(Shop newShop)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            try
            {
                db.Shops.Add(newShop);
                db.SaveChanges();

                response.Content = new StringContent(
                    "{IdShop:" + newShop.IdShop +
                    ",ShopName:" + newShop.Name +"}",
                    Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent(
                    "{Error:" + ex.Message + "}", Encoding.UTF8, "application/json");
            }

            return response;
        }


        [HttpPost]
        [ActionName("UpdateShop")]
        public HttpResponseMessage UpdateShop(Shop newShop)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var oldShop = (from o in db.Shops
                           where o.IdShop == newShop.IdShop
                           select o).First();
            try
            {
                db.Shops.Remove(oldShop);
                db.Shops.Add(newShop);
                db.SaveChanges();
                response.Content = new StringContent(
                       "{IdShop:" + newShop.IdShop +
                       ",ShopName:" + newShop.Name + "}",
                       Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent(
                    "{Error:" + ex.Message + "}", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPost]
        [ActionName("DeleteShop")]
        public HttpResponseMessage DeleteShop(Shop s)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var ds = (from t in db.Shops
                      where t.IdShop == s.IdShop
                      select t).First();
            try
            {
                db.Shops.Remove(ds);
                db.SaveChanges();
                response.Content = new StringContent(
                       "{IdShop:" + ds.IdShop +
                       ",ShopName:" + ds.Name + "}",
                       Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent(
                    "{Error:" + ex.Message + "}", Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}
