using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;
using System.Web.Http.WebHost;

namespace Lab2.Controllers
{
    public class ClassWorkController : Controller
    {
        private Lab2DBmdfEntities db = new Lab2DBmdfEntities();
        // GET: ClassWork
        public ActionResult Index()
        {
            var emps = (from Employee in db.Employees select Employee).ToList();
            return View(emps);
        }
        public ActionResult Details(int id)
        {
            var emps = (from Position in db.Positions
                        where Position.IdEmployee == id
                        select Position.Specialization).First();
            return View(emps);
        }
        
        //Create new Employee
        [HttpGet]
        public ActionResult Create()
        {
            Employee emp = new Employee();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(emp);
        }

        //Edit Employee
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empEdit = (from emp in db.Employees
                           where emp.IdEmployee == id
                           select emp).First();
            return View(empEdit);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var empEdit = (from emp in db.Employees
                           where emp.IdEmployee == id
                           select emp).First();
            try
            {
                UpdateModel(empEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(empEdit);
            }
        }

        //Delete Employee
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empDelete = (from emp in db.Employees
                             where emp.IdEmployee == id
                             select emp).First();
            return View(empDelete);
        }
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            var empDelete = (from emp in db.Employees
                             where emp.IdEmployee == id
                             select emp).First();
            try
            {
                db.Employees.Remove(empDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(empDelete);
            }
        }
    }
}