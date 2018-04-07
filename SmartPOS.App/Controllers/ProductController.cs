using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;

namespace SmartPOS.App.Controllers
{
    public class ProductController : Controller
    {
        CommonManager commonManager=new CommonManager();
        ProductManager productManager=new ProductManager();
        // GET: Product
        public ActionResult Product()
        {
            List<Product> products = productManager.GetAllProduct();
            ViewBag.Product = products;

            ViewBag.Items = GetItemForMaterailTypeDropdownList();
            ViewBag.Brand = GetItemForBrandDropdownList();
            ViewBag.Category = GetItemForCategoryDropdownList();
          
            return View();
          
        }

        [HttpPost]
        public ActionResult Product(ProductVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Product product = Mapper.Map<Entity.EntityModels.Product>(model);
                if (product.Id == 0)
                {
                    var extension = Path.GetExtension(model.Image1.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/Student/Photo/"));

                    if (!Directory.Exists(path))

                        Directory.CreateDirectory(path);

                    model.Image1.SaveAs(path + model.Id + extension);

                    ViewBag.message = productManager.Save(product);
                }
                else
                {
                    ViewBag.message = productManager.Update(product);
                }
                model = new ProductVm();
                ModelState.Clear();
            }
            ViewBag.Items = GetItemDropdownList();
            ViewBag.Brand = GetItemForBrandDropdownList();
            ViewBag.Category = GetItemForCategoryDropdownList();
            List<Product> products = productManager.GetAllProduct();
            ViewBag.Product = products;
            return View(model);
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

        private List<SelectListItem> GetItemForBrandDropdownList()
        {
            List<SelectListItem> brands = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common brand in GetAllBrand())
            {
                var item = new SelectListItem() { Value = brand.Id.ToString(), Text = brand.Name };
                brands.Add(item);
            }

            return brands;
        }
        private List<SelectListItem> GetItemForCategoryDropdownList()
        {
            List<SelectListItem> categories = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common category in GetAllCategory())
            {
                var item = new SelectListItem() { Value = category.Id.ToString(), Text = category.Name };
                categories.Add(item);
            }

            return categories;
        }
        public List<Common> GetAllBrand()
        {
            List<Common> Brands = commonManager.GetAllBrand();
            return Brands;
        }
        public List<Common> GetAllCategory()
        {
            List<Common> Brands = commonManager.GetAllCategories();
            return Brands;
        }
        private List<SelectListItem> GetItemForMaterailTypeDropdownList()
        {
            List<SelectListItem> Materials = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common material in GetAllMaterial())
            {
                var item = new SelectListItem() { Value = material.Id.ToString(), Text = material.Name };
                Materials.Add(item);
            }

            return Materials;
        }

        public List<Common> GetAllMaterial()
        {
            List<Common> materialTypes = commonManager.GetAllItem();
            return materialTypes;
        }

        //public ActionResult FillCategory(int state)
        //{
        //    var cities = db.Cities.Where(c => c.StateId == state);
        //    return Json(cities, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult FillCategory(int id)
        {
            List<Brand> brand = productManager.FillCategory(id).ToList();

          // Category category = productManager.FillCategory(id);
            return Json(brand, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductById(int id)
        {
            Product product = productManager.GetById(id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        private Bitmap GenerateBarcode(int productId)
        {
            string barcode = productId.ToString("0000000000");
            using (MemoryStream ms = new MemoryStream())
            {
                //The Image is drawn based on length of Barcode text.
                using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
                {
                    //The Graphics library object is generated for the Image.
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //The installed Barcode font.
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);

                        //White Brush is used to fill the Image with white color.
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        //Black Brush is used to draw the Barcode over the Image.
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                    }

                    //The Bitmap is saved to Memory Stream.
                    //bitMap.Save(ms, ImageFormat.Png);
                    //bitMap.Save(@"E:\test\123.png");
                    return bitMap;
                }
            }
        }
    }
}