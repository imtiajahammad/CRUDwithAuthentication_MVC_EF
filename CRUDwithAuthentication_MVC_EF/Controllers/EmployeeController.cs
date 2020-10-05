using CRUDwithAuthentication_MVC_EF.DataLayer;
using CRUDwithAuthentication_MVC_EF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDwithAuthentication_MVC_EF.Controllers
{
    public class EmployeeController : Controller
    {
        protected ApplicationDbContext applicationDbContext { get; set; }
        protected UserManager<ApplicationUser> userManager { get; set; }


        public EmployeeController()
        {
            this.applicationDbContext = new ApplicationDbContext();
            this.userManager = new UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>
                (this.applicationDbContext));
        }

        // GET: Employee
        [Authorize]
        public ActionResult Index()
        {
            List<Employee> employees=applicationDbContext.Employees.ToList();
            return View(employees);
        }

        [Authorize]
        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            var aa = User.Identity.GetUserId();
            Employee employee = applicationDbContext.Employees
                .Where(emp => emp.userid == aa ).FirstOrDefault();
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                employee.userid = User.Identity.GetUserId();
                /*employee.User=System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());*/
                employee.User = userManager
                    .FindById(User.Identity.GetUserId());
                applicationDbContext.Employees.Add(employee);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(employee);
            }
        }

        [Authorize]
        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            var currentUserid = User.Identity.GetUserId();
            /*Employee employee = applicationDbContext.Employees.Where(emp => emp.Id == id).FirstOrDefault();*/
            Employee employee = applicationDbContext.Employees
                .Where(emp => emp.userid == currentUserid).FirstOrDefault();
            return View(employee);
        }
        [Authorize]
        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                employee.userid = User.Identity.GetUserId();
                employee.User = userManager
                    .FindById(User.Identity.GetUserId());
                applicationDbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = applicationDbContext.Employees.Where(emp => emp.Id == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                Employee empSelected = applicationDbContext.Employees.Where(emp => emp.Id == id).FirstOrDefault();
                applicationDbContext.Employees.Remove(empSelected);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }
    }
}
