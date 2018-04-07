using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class BrandManager
    {
        BrandGateway brandGateway=new BrandGateway();
        public String Save(Brand brand)
        {
            int rowAfftected = brandGateway.Save(brand);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public Brand GetById(int id)
        {
            return brandGateway.GetById(id);
        }

        public string Update(Brand brand)
        {
            int rowAfftected = brandGateway.Update(brand);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }
    }
}
