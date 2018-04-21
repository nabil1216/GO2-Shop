using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;
namespace SmartPOS.Manager
{
    public class DiscountManager
    {
        DiscountGateway discoutGateway = new DiscountGateway(); 
        public List<Discount> GetAllDiscount()
        {
              return discoutGateway.GetAllDiscount();
        }


        public string Save(Discount discount)
        {
            int rowAfftected = discoutGateway.Save(discount);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public string Update(Discount discount)
        {
            int rowAfftected = discoutGateway.Update(discount);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public Discount GetById(int id)
        {
            return discoutGateway.GetById(id);
        }
    }
}
