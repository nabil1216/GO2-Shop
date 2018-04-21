using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPOS.App.Controllers
{
    public class DiscountController : Controller
    {
        DiscountManager discountManager = new DiscountManager();
        // GET: Discount
        public ActionResult Discount()
        {
            List<Discount> discounts = discountManager.GetAllDiscount();
            ViewBag.Discount = discounts;
            return View();
        }

        [HttpPost]
        public ActionResult Discount(DiscountVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Discount discount = Mapper.Map<Entity.EntityModels.Discount>(model);
                if (discount.Id == 0)
                {
                    ViewBag.message = discountManager.Save(discount);
                }
                else
                {
                    ViewBag.message = discountManager.Update(discount);
                }
                model = new DiscountVm();
                ModelState.Clear();
            }
            List<Discount> discounts = discountManager.GetAllDiscount();
            ViewBag.Discount = discounts;
            return View(model);
        }

        public JsonResult GetItemById(int id)
        {
            Discount discount = discountManager.GetById(id);
            return Json(discount, JsonRequestBehavior.AllowGet);
        }
    }
}