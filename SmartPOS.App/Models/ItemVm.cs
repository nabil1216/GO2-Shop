using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class ItemVm
    {
        public int? Id { get; set; }
        [Required]
        [DisplayName("Item Name")]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}