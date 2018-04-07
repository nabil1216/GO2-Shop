using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;
namespace SmartPOS.Manager
{
   public class HeadOfficeManager
    {
        HeadOfficeGateway headOfficeGateway=new HeadOfficeGateway();
        public List<HeadOffice> GetAllHeadOffice()
        {
            return headOfficeGateway.GetAllHeadOffice();
        }

        public String Save(HeadOffice headOffice)
        {
            int rowAfftected = headOfficeGateway.Save(headOffice);

            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public string Update(HeadOffice headOffice)
        {
            int rowAfftected = headOfficeGateway.Update(headOffice);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }
        public HeadOffice GetById(int id)
        {
            return headOfficeGateway.GetById(id);
        }
    }
}
