using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
   public class SupplierManager
    {
        SupplierGateway supplierGateway=new SupplierGateway();

        public List<Supplier> GetAllSuppliers()
        {
            return supplierGateway.GetAllSuppliers();
        }

        public String Save(Supplier supplier)
        {
            int rowAfftected = supplierGateway.Save(supplier);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public Supplier GetById(int id)
        {
            return supplierGateway.GetById(id);
        }

        public string Update(Supplier supplier)
        {
            int rowAfftected = supplierGateway.Update(supplier);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }
    }
}
