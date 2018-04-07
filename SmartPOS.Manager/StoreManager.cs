using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
 public   class StoreManager
    {
        StoreGateway storeGateway=new StoreGateway();

        public List<Store> GetAllStore()
        {
            return storeGateway.GetAllStore();
        }
        public String Save(Store store)
        {
            int rowAfftected = storeGateway.Save(store);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public string Update(Store store)
        {
            int rowAfftected = storeGateway.Update(store);

            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public Store GetById(int id)
        {
            return storeGateway.GetById(id);
        }
    }
}
