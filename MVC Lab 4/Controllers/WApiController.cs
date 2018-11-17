using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Lab_4.Models;

namespace MVC_Lab_4.Controllers
{
    public class WApiController : ApiController
    {
        private Lab2DBmdfEntities db = new Lab2DBmdfEntities();

        public ICollection<EmployeePerson> GetEmp()
        {
            var emps = (from employees in db.Employees
                        select employees).ToList();
            Collection<EmployeePerson> EP = new Collection<EmployeePerson>();
            foreach(Employee e in emps)
            {
                EP.Add(new EmployeePerson { Id = e.IdEmployee, Name = e.Name });
            }
            return EP;
        }

        public ICollection<PersonSpecialization> GetPos(int id)
        {
            var emps = (from pos in db.Positions
                        where pos.IdEmployee == id
                        select pos.Specialization).ToList();
            ICollection<PersonSpecialization> PS = new Collection<PersonSpecialization>();
            foreach(Specialization p in emps)
            {
                PS.Add(new PersonSpecialization
                {
                    Id = p.IdSpec,
                    Name = p.Name
                });
            }
            return PS;
        }
    }
}
