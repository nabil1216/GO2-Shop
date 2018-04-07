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
    public class VatController : Controller
    {
        CommonManager commonManager = new CommonManager();
        VatManager vatManager=new VatManager();
        // GET: Vat
        public ActionResult Vat()
        {
            List<Vat> vats = vatManager.GetAllVat();
            ViewBag.Vat = vats;
            return View();
        }

        [HttpPost]
        public ActionResult Vat(VatVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Vat vat = Mapper.Map<Entity.EntityModels.Vat>(model);
                if (vat.Id == 0)
                {
                    ViewBag.message = vatManager.Save(vat);
                }
                else
                {
                    ViewBag.message = vatManager.Update(vat);
                }
                model = new VatVm();
                ModelState.Clear();
            }
            List<Vat> vats = vatManager.GetAllVat();
            ViewBag.Vat = vats;
            return View(model);
        }

        public JsonResult GetVatById(int id)
        {
            Vat vat = vatManager.GetById(id);
            return Json(vat, JsonRequestBehavior.AllowGet);
        }
    }
}