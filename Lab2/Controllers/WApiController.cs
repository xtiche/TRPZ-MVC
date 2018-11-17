using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class WApiController : ApiController
    {
        Lab2DBmdfEntities db = new Lab2DBmdfEntities();
        [HttpGet]
        [ActionName("GetEmp")]
        public ICollection<Employee> GetEmployees()
        {
            var emps = (from employeers in db.Employees
                        select employeers).ToList();

            Collection<Employee> EMP = new Collection<Employee>();
            foreach (Employee item in emps)
            {
                EMP.Add(new Employee
                {
                    IdEmployee = item.IdEmployee,
                    Name = item.Name,
                    Age = item.Age
                });
            }
            return EMP;
        }


        [HttpGet]
        [ActionName("GetSpec")]
        public ICollection<Specialization> GetSpecializations(int id)
        {
            var spec = (from pos in db.Positions
                        where pos.IdEmployee == id
                        select pos.Specialization).ToList();
            Collection<Specialization> SP = new Collection<Specialization>();
            foreach (Specialization item in spec)
            {
                SP.Add(new Specialization
                {
                    IdSpec = item.IdSpec,
                    Name = item.Name
                });
            }
            return SP;
        }

        [HttpPost]
        [ActionName("CreateEmp")]
        public HttpResponseMessage CreateEmp(Employee emp)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                response.Content = new StringContent(
                    "{Id:" + emp.IdEmployee + "," +
                    "Name:" + emp.Name + "," +
                    "Age:" + emp.Age + "}",
                    Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("Error:" + ex.Message.ToString() + "}",
                    Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPost]
        [ActionName("UpdateEmp")]
        public HttpResponseMessage UpdateEmp(Employee sEmp)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var oldEmp = (from emps in db.Employees
                          where emps.IdEmployee == sEmp.IdEmployee
                          select emps).First();
            try
            {
                db.Employees.Remove(oldEmp);
                db.Employees.Add(sEmp);
                db.SaveChanges();
                response.Content = new StringContent(
                    "{Id:"  + sEmp.IdEmployee   + "," +
                    "Name:" + sEmp.Name         + "," +
                    "Age:"  + sEmp.Age          + "}",
                    Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("Error:" + ex.Message.ToString() + "}",
                    Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPost]
        [ActionName("DeleteEmp")]
        public HttpResponseMessage DeleteEmp(Employee Emp)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var sEmp = (from o in db.Employees where o.IdEmployee == Emp.IdEmployee select o).First();
            try
            {
                db.Employees.Remove(sEmp);
                db.SaveChanges();
                response.Content = new StringContent(
                    "{Id:" + sEmp.IdEmployee + "," +
                    "Name:" + sEmp.Name      + "," +
                    "Age:" + sEmp.Age        + "}",
                    Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("Error:" + ex.Message.ToString() + "}",
                    Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}

