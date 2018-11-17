using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1HW.Models;

namespace Lab1HW.Controllers
{
    public class StringCheckController : Controller
    {
        // GET: StringCheck
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MyString model)
        {
            string result = string.Empty;
            try
            {
                result = model.operand.Replace('a', '#');
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