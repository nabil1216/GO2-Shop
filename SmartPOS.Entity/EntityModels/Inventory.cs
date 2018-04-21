using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Entity.EntityModels
{
   public class Inventory
    {
        public int Id { get; set; }
      //  public int Quantity { get; set; }
        public string ProductId { get; set; }

        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string ItemId { get; set; }
        public string CategoryId { get; set; }
        public string Price { get; set; }
        public string Decrease { get; set; }

        public string SellQuantity { get; set; }
        public string SellAmount { get; set; }

        public string Increase { get; set; }
        public string DiscountAmount { get; set; }
        public string SellPrice { get; set; }
      
    }
}
