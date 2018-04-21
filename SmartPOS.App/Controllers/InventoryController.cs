using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPOS.App.Controllers
{
    public class InventoryController : Controller
    {
        CommonManager commonManager = new CommonManager();
        InventoryManager inventoryManager=new InventoryManager();

        // GET: Inventory
        public ActionResult Inventory()
        {
            List<Inventory> inventories = inventoryManager.GetAllInventory();
            ViewBag.Inventory = inventories;
            return View();
        }
        public JsonResult FillProductList(string prefix)
        {
            List<Common> common = commonManager.GetAllProduct(prefix).ToList();

            // Category category = productManager.FillCategory(id);
            return Json(common, JsonRequestBehavior.AllowGet);
        }
    }
}