using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class InventoryVm
    {
        public int Id { get; set; }
        [Required]
        public string Quanitity { get; set; }
        [Required]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }
        public string  Name { get; set; }
        public string ProductId { get; set; }
        [DisplayName("Display Name")]
        public string ProductName { get; set; }
        [DisplayName("Buying Price")]
        public string Price { get; set; }
        public string Decrease { get; set; }


        public string Increase { get; set; }
        [DisplayName("Percent")]
        public string DiscountPercent { get; set; }
        [DisplayName("Discount Amount")]
        public string DiscountAmount { get; set; }
        public string SellQuantity { get; set; }
        public string SellPrice { get; set; }



    }
}