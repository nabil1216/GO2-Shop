using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(conf =>
            {
                conf.CreateMap<CategoryVm, Category>();
                conf.CreateMap<Category, CategoryVm>();

                conf.CreateMap<ItemVm, Item>();
                conf.CreateMap<Item, ItemVm>();

                conf.CreateMap<ProductVm, Product>();
                conf.CreateMap<Product, ProductVm>();

                conf.CreateMap<UnitVm, Unit>();
                conf.CreateMap<Unit, UnitVm>();

                conf.CreateMap<ProductVm, Product>();
                conf.CreateMap<Product, ProductVm>();

                conf.CreateMap<PurchaseOrderVm, PurchaseOrder>();
                conf.CreateMap<PurchaseOrder, PurchaseOrderVm>();

                conf.CreateMap<UserVm, User>();
                conf.CreateMap<User, UserVm>();

            });
        }
    }
}
