using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class CategoryVm
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Item")]
        [Required]
        public string ItemId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}