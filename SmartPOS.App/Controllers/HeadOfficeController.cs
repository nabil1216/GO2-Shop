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
    public class HeadOfficeController : Controller
    {
        HeadOfficeManager headOfficeManager=new HeadOfficeManager();
        // GET: HeadOffice
        public ActionResult HeadOffice()
        {
            List<HeadOffice> headOffices = headOfficeManager.GetAllHeadOffice();
            ViewBag.HeadOffice = headOffices;
            return View();
        }

        //save
        [HttpPost]
        public ActionResult HeadOffice(HeadOfficeVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.HeadOffice headOffice = Mapper.Map<Entity.EntityModels.HeadOffice>(model);
                if (headOffice.Id == 0)
                {
                    ViewBag.message = headOfficeManager.Save(headOffice);
                }
                else
                {
                    ViewBag.message = headOfficeManager.Update(headOffice);
                }
                model = new HeadOfficeVm();
                ModelState.Clear();
            }
            List<HeadOffice> headOffices = headOfficeManager.GetAllHeadOffice();
            ViewBag.HeadOffice = headOffices;
            return View(model);
        }

        public JsonResult GeHeadOfficeById(int id)
        {
            HeadOffice headOffice = headOfficeManager.GetById(id);
            return Json(headOffice, JsonRequestBehavior.AllowGet);
        }
    }
}