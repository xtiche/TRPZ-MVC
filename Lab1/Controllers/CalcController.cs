using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(OperandsModel model)
        {
            string result = string.Empty;
            try
            {
                result = string.Format("Разница: {0}, Остача от деления: {1}", model.Num1 - model.Num2, model.Num1%model.Num2);
            }
            catch (Exception e)
            {
                result = e.Message.ToString(); 
            }
            ViewBag.Result = result;

            return View();
        }
    }
}