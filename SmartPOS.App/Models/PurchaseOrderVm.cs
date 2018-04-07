using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class PurchaseOrderVm
    {
        public int? Id { get; set; }
        [DisplayName("Model No")]
        public string ModelNo { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public string OrderNo { get; set; }
        public string OrderQuantity { get; set; }
        public string Supplier { get; set; }
        public string Amount { get; set; }
        public string ProductId { get; set; }
        public string Price { get; set; }
        [DisplayName("Order Date")]
        public string OrderDate { get; set; }
    }
}