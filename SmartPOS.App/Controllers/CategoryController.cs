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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager=new CategoryManager();
        CommonManager commonManager=new CommonManager();
        // GET: Category
        public ActionResult Category()
        {
            List<Category> categories = categoryManager.GetAllCategories();
            ViewBag.Category = categories;

            ViewBag.Item = GetItemDropdownList();
            return View();
            
        }
      

        [HttpPost]
        public ActionResult Category(CategoryVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Category category = Mapper.Map<Entity.EntityModels.Category>(model);
                if (category.Id == 0)
                {
                    ViewBag.message = categoryManager.Save(category);
                }
                else
                {
                    ViewBag.message = categoryManager.Update(category);
                }
                model = new CategoryVm();
                ModelState.Clear();
            }
            List<Category> categories = categoryManager.GetAllCategories();
            ViewBag.Category = categories;

           // List<Common> items = commonManager.GetAllItem();
            ViewBag.Item = GetItemDropdownList();
            return View(model);
        }

        public JsonResult GetCategoryById(int id)
        {
            Category category = categoryManager.GetById(id);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetItemDropdownList()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common Item in GetAllItem())
            {
                var item = new SelectListItem() { Value = Item.Id.ToString(), Text = Item.Name };
                items.Add(item);
            }

            return items;
        }

        public List<Common> GetAllItem()
        {
            List<Common> Brands = commonManager.GetAllItem();
            return Brands;
        }

    }
}