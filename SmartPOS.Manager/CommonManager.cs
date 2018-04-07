using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;
namespace SmartPOS.Manager
{
  public  class CommonManager
    {
        CommonGateway commonGateway=new CommonGateway();
        public List<Common> GetAllCategories()
        {
            return commonGateway.GetAllCategories();
        }

        public List<Common> GetAllPurchaseOrders()
        {
            return commonGateway.GetAllPurchaseOrders();

        }

        public List<Common> GetAllModelNo()
        {
            return commonGateway.GetAllModelNo();

        }

        public List<Common> GetAllBrand()
        {
            return commonGateway.GetAllBrand();
        }
        public List<Common> GetAllUnit()
        {
            return commonGateway.GetAllUnit();
        }
        public List<Common> GetAllProduct(string prefix )
        {
            return commonGateway.GetAllProduct(prefix);
        }

        //public List<Common> GetAllVat()
        //{
        //    return commonGateway.GetAllVat();
        //}
        public List<Common> GetAllItem()
        {
            return commonGateway.GetAllItem();
        }

        public List<Common> GetAllSuppliers()
        {
            return commonGateway.GetAllSuppliers();
        }
    }
}
