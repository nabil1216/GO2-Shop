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
    public class StoreController : Controller
    {
        StoreManager storeManager=new StoreManager();
        // GET: Store
        public ActionResult Store()
        {
            List<Store> stores = storeManager.GetAllStore();
            ViewBag.Store = stores;
            return View();
        }

        [HttpPost]
        public ActionResult Store(StoreVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Store store = Mapper.Map<Entity.EntityModels.Store>(model);
                if (store.Id == 0)
                {
                    ViewBag.message = storeManager.Save(store);
                }
                else
                {
                    ViewBag.message = storeManager.Update(store);
                }
                model = new StoreVm();
                ModelState.Clear();
            }
            List<Store> stores = storeManager.GetAllStore();
            ViewBag.Store = stores;
            return View(model);
        }

        public JsonResult GetStoreById(int id)
        {
            Store store = storeManager.GetById(id);
            return Json(store, JsonRequestBehavior.AllowGet);
        }
    }
}