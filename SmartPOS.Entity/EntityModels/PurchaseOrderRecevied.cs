using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Entity.EntityModels
{
   public class PurchaseOrderRecevied
    {
        public int Id { get; set; }
        public string ReceivedQuantity { get; set; }

        public string ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ModelNo { get; set; }
        public string ProductName { get; set; }
        public string RemainingQty { get; set; }
        public string OrderNo { get; set; }
        public string PurchaseOrderQuantity { get; set; }
    }
}
