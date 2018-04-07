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
    public class UnitController : Controller
    {
        CommonManager commonManager = new CommonManager();
        UnitManager unitManager=new UnitManager();
        // GET: Unit
        public ActionResult Unit()
        {
            List<Common> units = commonManager.GetAllUnit();
            ViewBag.Unit = units;
            return View();
        }

        [HttpPost]
        public ActionResult Unit(UnitVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Unit unit = Mapper.Map<Entity.EntityModels.Unit>(model);
                if (unit.Id == 0)
                {
                    ViewBag.message = unitManager.Save(unit);
                }
                else
                {
                    ViewBag.message = unitManager.Update(unit);
                }
                model = new UnitVm();
                ModelState.Clear();
            }
            List<Common> units = commonManager.GetAllUnit();
            ViewBag.Unit = units;
            return View(model);
        }

        public JsonResult GetUnitById(int id)
        {
            Unit unit = unitManager.GetById(id);
            return Json(unit, JsonRequestBehavior.AllowGet);
        }

    }
}