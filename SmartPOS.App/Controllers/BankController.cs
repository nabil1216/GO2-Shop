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
    public class BankController : Controller
    {
        BankManager bankManager=new BankManager();
        // GET: Bank
        public ActionResult Bank()
        {
            List<Bank> banks = bankManager.GetAllBank();
            ViewBag.Bank = banks;
            return View();
        }

        [HttpPost]
        public ActionResult Bank(BankVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Bank currency = Mapper.Map<Entity.EntityModels.Bank>(model);
                if (currency.Id == 0)
                {
                    ViewBag.message = bankManager.Save(currency);
                }
                else
                {
                    ViewBag.message = bankManager.Update(currency);
                }
                model = new BankVm();
                ModelState.Clear();
            }
            List<Bank> banks = bankManager.GetAllBank();
            ViewBag.Bank = banks;
            return View(model);
        }

        public JsonResult GetBankById(int id)
        {
            Bank bank = bankManager.GetById(id);
            return Json(bank, JsonRequestBehavior.AllowGet);
        }

    }
}