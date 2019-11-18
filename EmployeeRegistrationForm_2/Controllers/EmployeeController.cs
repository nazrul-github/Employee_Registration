using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeRegistrationForm_2.Models;
using EmployeeRegistrationForm_2.Models.DAL;

namespace EmployeeRegistrationForm_2.Controllers
{
    public class EmployeeController : Controller
    {
        EmloyeeDbContext emloyeeDbContext = new EmloyeeDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var allEmployee = emloyeeDbContext.GetAllEmployees;
            return View(allEmployee);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            Employee aEmployee = new Employee();
            if (ModelState.IsValid)
            {
                TryUpdateModel(aEmployee);
                emloyeeDbContext.CreateEmployee(aEmployee);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee aEmployee = new Employee();
            aEmployee = emloyeeDbContext.GetAllEmployees.Single(emp => emp.Id == id);
            return View(aEmployee);
        }
    }
}