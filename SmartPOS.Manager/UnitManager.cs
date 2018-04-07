using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class UnitManager
    {
        UnitGateway unitGateway = new UnitGateway();
        public String Save(Unit unit)
        {
            int rowAfftected = unitGateway.Save(unit);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public string Update(Unit unit)
        {
            int rowAfftected = unitGateway.Update(unit);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public Unit GetById(int id)
        {
            return unitGateway.GetById(id);
        }

    }
}
