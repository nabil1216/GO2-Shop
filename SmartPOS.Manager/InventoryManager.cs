using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
   public class InventoryManager
    {
        InventoryGateway inventoryGateway=new InventoryGateway();
        public List<Inventory> GetAllInventory()
        {
            return inventoryGateway.GetAllInventory();
        }
    }
}
