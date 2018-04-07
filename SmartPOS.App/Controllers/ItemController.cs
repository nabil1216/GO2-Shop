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
    public class ItemController : Controller
    {
     ItemManager _itemManager=new ItemManager();   
        CommonManager commonManager= new CommonManager();
        // GET: Item
        public ActionResult Item()
        {
            List<Common> items = commonManager.GetAllItem();
            ViewBag.Item = items;
            return View();
        }

        [HttpPost]
        public ActionResult Item(ItemVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Item item = Mapper.Map<Entity.EntityModels.Item>(model);
                if (item.Id == 0)
                {
                    ViewBag.message = _itemManager.Save(item);
                }
                else
                {
                    ViewBag.message = _itemManager.Update(item);
                }
                model = new ItemVm();
                ModelState.Clear();
            }
            List<Common> items = commonManager.GetAllItem();
            ViewBag.Item = items;
            return View(model);
        }

        public JsonResult GetItemById(int id)
        {
            Item item = _itemManager.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}