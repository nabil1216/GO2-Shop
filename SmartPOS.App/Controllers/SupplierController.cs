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
    public class SupplierController : Controller
    {
        SupplierManager supplierManager=new SupplierManager();
        // GET: Supplier
        public ActionResult Supplier()
        {
            List<Supplier> suppliers = supplierManager.GetAllSuppliers();
            ViewBag.Supplier = suppliers;
            return View();
        }

        [HttpPost]
        public ActionResult Supplier(SupplierVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Supplier supplier = Mapper.Map<Entity.EntityModels.Supplier>(model);
                if (supplier.Id == 0)
                {
                    ViewBag.message = supplierManager.Save(supplier);
                }
                else
                {
                    ViewBag.message = supplierManager.Update(supplier);
                }
                model = new SupplierVm();
                ModelState.Clear();
            }
            List<Supplier> suppliers = supplierManager.GetAllSuppliers();
            ViewBag.Supplier = suppliers;
            return View(model);
        }

        public JsonResult GetSupplierById(int id)
        {
            Supplier supplier = supplierManager.GetById(id);
            return Json(supplier, JsonRequestBehavior.AllowGet);
        }
    }
}