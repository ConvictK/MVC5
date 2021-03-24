using ASP.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.MVC5.Controllers
{
    public class EmployeeController : Controller
    {
        private TechTestDBEntities _pPECBdbModel = new TechTestDBEntities();
        private TechTestDBEntities db = new TechTestDBEntities();


        // GET: Employee
        public ActionResult Index()
        {
            return View(_pPECBdbModel.Employees.ToList<Employee>());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) 
            {
                return HttpNotFound();
            }
            var e = _pPECBdbModel.Employees.Find(id);
            if (e == null)
            {
                return View();
            }
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee E)
        {
            if (ModelState.IsValid) 
            {
                _pPECBdbModel.Entry(E).State = EntityState.Modified;
                _pPECBdbModel.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(E);

          
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee E)
        {
            if (ModelState.IsValid)
            {
                _pPECBdbModel.Employees.Add(E);
                _pPECBdbModel.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return HttpNotFound();
            }
            var d = _pPECBdbModel.Employees.Find(id);
            return View(d);

        }
        [HttpPost]
        public ActionResult Delete(Employee E)
        {
            if (E == null)
            {
                return HttpNotFound();
            }

            var d = _pPECBdbModel.Employees.Find(E.id);
            _pPECBdbModel.Employees.Remove(d);
            _pPECBdbModel.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var d = _pPECBdbModel.Employees.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }


            return View(d);

        }
    }
}