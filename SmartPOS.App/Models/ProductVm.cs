using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class ProductVm
    {
        public int? Id { get; set; }
        [DisplayName("Items")]
        public string ItemId { get; set; }
        [DisplayName("Brand")]
        public string BrandId { get; set; }
        [DisplayName("Image")]
        public byte[] Image1 { get; set; }

        
        [DisplayName("Front Image")]
        public byte[] Image2 { get; set; }
        [DisplayName("Category")]
        public string CategoryId { get; set; }
        [DisplayName("Code No")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$",ErrorMessage = "Enter only Number")]
        public string Price { get; set; }
        public string Quantity { get; set; }
      
    }
}