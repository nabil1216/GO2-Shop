using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

using SmartPOS.Gateway;
namespace SmartPOS.Manager
{
    public class ItemManager
    {
        ItemGateway _itemGateway=new ItemGateway();

        public String Save(Item item)
        {
            int rowAfftected = _itemGateway.Save(item);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public List<Item> GetAllMaterialTypes()
        {
            return _itemGateway.GetAllMaterialTypes();
        }

        public string Update(Item item)
        {
            int rowAfftected = _itemGateway.Update(item);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public Item GetById(int id)
        {
            return _itemGateway.GetById(id);
        }
    }
}
