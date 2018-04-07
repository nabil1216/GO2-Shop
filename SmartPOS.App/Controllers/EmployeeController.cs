using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;

namespace SmartPOS.App.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager=new EmployeeManager();

        // GET: Employee
        public ActionResult Employee()
        {
            List<Employee> employees = employeeManager.GetAllEmployees();
            ViewBag.Employee = employees;
            return View();
        }

        [HttpPost]
        public ActionResult Employee(EmployeeVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Employee employee = Mapper.Map<Entity.EntityModels.Employee>(model);
                if (employee.Id == 0)
                {
                    ViewBag.message = employeeManager.Save(employee);
                }
                else
                {
                    ViewBag.message = employeeManager.Update(employee);
                }
                model = new EmployeeVm();
                ModelState.Clear();
            }
            List<Employee> employees = employeeManager.GetAllEmployees();
            ViewBag.Employee = employees;
            return View(model);
        }

        public JsonResult GetEmployeeById(int id)
        {
            Employee employee = employeeManager.GetById(id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}