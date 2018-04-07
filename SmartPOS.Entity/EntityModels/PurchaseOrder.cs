using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Entity.EntityModels
{
  public  class PurchaseOrder
    {
        public int Id { get; set; }
        public string Price { get; set; }
        public string OrderQuantity { get; set; }
        public string OrderNo { get; set; }
        public string ModelNo { get; set; }

        public string Supplier { get; set; }
       // public string ProductName { get; set; }
        public string Amount { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }

        public string OrderDate { get; set; }

    }
}
