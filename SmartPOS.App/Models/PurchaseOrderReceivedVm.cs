using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class PurchaseOrderReceivedVm
    {
        public int Id { get; set; }
        [Required]
        public string ReceivedQuantity { get; set; }
        [Required]
        
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