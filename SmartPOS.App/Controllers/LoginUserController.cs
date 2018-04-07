using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Manager;

namespace SmartPOS.App.Controllers
{
    public class LoginUserController : Controller
    {
        UserManager userManager=new UserManager();
        // GET: UserController
        

        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(UserVm model)
        {
            Entity.EntityModels.User user = Mapper.Map<Entity.EntityModels.User>(model);
            {
                if (user.Id == 0)
                {
                    int row = userManager.ValidityCheck(user);
                    if (row != 0)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                        return RedirectToAction("Dashboard", "Test");
                    }
                    else
                    {
                       ModelState.AddModelError("", "Login data is incorrect!");
                        //ViewBag.message = "Login data is incorrect!";
                    }
                }


            }

            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}