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
    public class TestController : Controller
    {
        CountryManager countryManager=new CountryManager();
        
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Country()
        {
            List<Country> countries = countryManager.GetAllCountries();
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public ActionResult Country(CountryVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Country country = Mapper.Map<Entity.EntityModels.Country>(model);
                if (country.Id == 0)
                {
                    ViewBag.message = countryManager.Save(country);
                }
                else
                {
                    ViewBag.message = countryManager.Update(country);
                }
                model= new CountryVm();
                ModelState.Clear();
            }
            List<Country> countries = countryManager.GetAllCountries();
            ViewBag.Countries = countries;
            return View(model);
        }

        public JsonResult GetCountryById(int id)
        {
            Country country = countryManager.GetById(id);
            return Json(country, JsonRequestBehavior.AllowGet);
        }
    }
}