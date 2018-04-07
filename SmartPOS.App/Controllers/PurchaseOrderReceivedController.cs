using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartPOS.Manager;
using System.IO;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;
namespace SmartPOS.App.Controllers
{
    public class PurchaseOrderReceivedController : Controller
    {
        PurchaseOrderReceivedManager purchaseOrderReceivedManager =new PurchaseOrderReceivedManager();
        CommonManager commonManager=new CommonManager();
        // GET: PurchaseOrderReceived
        public ActionResult PurchaseOrderReceived()
        {
            ViewBag.PurchaseOrder = GetItemForPurchaseOrderDropdownList();
            ViewBag.ModelNo = GetItemForModelNoDropdownList();

            return View();
        }
        public List<Common> GetAllPurchaseOrder()
        {
            List<Common> purchaseOrders = commonManager.GetAllPurchaseOrders();
            return purchaseOrders;
        }

        public List<Common> GetAllModelNo()
        {
            List<Common> modelNos = commonManager.GetAllModelNo();
            return modelNos;
        }


        private List<SelectListItem> GetItemForPurchaseOrderDropdownList()
        {
            List<SelectListItem> purchaseOrders = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common purchaseOrder in GetAllPurchaseOrder())
            {
                var item = new SelectListItem() { Value = purchaseOrder.Id.ToString(), Text = purchaseOrder.Name };
                purchaseOrders.Add(item);
            }

            return purchaseOrders;
        }

        private List<SelectListItem> GetItemForModelNoDropdownList()
        {
            List<SelectListItem> modelnos = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common modelno in GetAllModelNo())
            {
                var item = new SelectListItem() { Value = modelno.Id.ToString(), Text = modelno.Name };
                modelnos.Add(item);
            }

            return modelnos;
        }


        public JsonResult FillPurchaseOrderReceived(int id)
        {
            List<PurchaseOrder> purchaseOrder = purchaseOrderReceivedManager.FillPurchaseOrderReceived(id).ToList();

            // Category category = productManager.FillCategory(id);
            return Json(purchaseOrder, JsonRequestBehavior.AllowGet);
        }
    }
}