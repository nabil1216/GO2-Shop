using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class VatManager
    {
        VatGateway vatGateway=new VatGateway();
        public String Save(Vat Vat)
        {
            int rowAfftected = vatGateway.Save(Vat);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public Vat GetById(int id)
        {
            return vatGateway.GetById(id);
        }

        public string Update(Vat vat)
        {
            int rowAfftected = vatGateway.Update(vat);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public List<Vat> GetAllVat()
        {
            return vatGateway.GetAllVat();
        }
    }
}
