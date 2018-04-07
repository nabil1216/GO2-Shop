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
    public class BranchOfficeController : Controller
    {
        BranchOfficeManager branchOfficeManager=new BranchOfficeManager();
        HeadOfficeManager headOfficeManager= new HeadOfficeManager();
        // GET: BranchOffice
        public ActionResult BranchOffice()
        {
            ViewBag.HeadOffice = GetItemForHeadOfficeDropdownList();
            List<BranchOffice> branchOffices = branchOfficeManager.GetAllBranches();
            ViewBag.BranchOffice = branchOffices;
            return View();
        }

        private List<SelectListItem> GetItemForHeadOfficeDropdownList()
        {
            List<SelectListItem> headOffices = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (HeadOffice headOffice in GetAllHeadOffice())
            {
                var item = new SelectListItem() { Value = headOffice.Id.ToString(), Text = headOffice.Name };
                headOffices.Add(item);
            }

            return headOffices;
        }

        public List<HeadOffice> GetAllHeadOffice()
        {
            List<HeadOffice> headOffices = headOfficeManager.GetAllHeadOffice();
            return headOffices;
        }

        [HttpPost]
        public ActionResult BranchOffice(BranchOfficeVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.BranchOffice branchOffice = Mapper.Map<Entity.EntityModels.BranchOffice>(model);
                if (branchOffice.Id == 0)
                {
                    ViewBag.message = branchOfficeManager.Save(branchOffice);
                }
                else
                {
                    ViewBag.message = branchOfficeManager.Update(branchOffice);
                }
                model = new BranchOfficeVm();
                ModelState.Clear();
            }
            List<BranchOffice> branchOffices = branchOfficeManager.GetAllBranches();
            ViewBag.BranchOffice = branchOffices;

            List<HeadOffice> headOffices = headOfficeManager.GetAllHeadOffice();
            ViewBag.HeadOffice = GetItemForHeadOfficeDropdownList();
            return View(model);
        }

        public JsonResult GetBranchOfficeById(int id)
        {
            BranchOffice branchOffice = branchOfficeManager.GetById(id);
            return Json(branchOffice, JsonRequestBehavior.AllowGet);
        }
    }
}