using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
   public class InventoryGateway:ConnectionGateway
    {
        public List<Inventory> GetAllInventory()
        {
            try
            {
                Query = "SELECT * From tbl_Inventory";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Inventory> Inventories = new List<Inventory>();
                while (Reader.Read())
                {
                    Inventory inventory = new Inventory()
                    {
                        Id = (int)Reader["InventoryId"],


                        Quantity = (int)Reader["Quantity"],
                        ProductId = Reader["ProductId"].ToString(),
                        SellPrice = Reader["SellingPrice"].ToString(),
                        DiscountAmount = Reader["DiscountAmount"].ToString()
                    };

                    Inventories.Add(inventory);


                }

                Reader.Close();
                return Inventories;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }
    }
}
