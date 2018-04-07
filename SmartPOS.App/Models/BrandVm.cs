using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class BrandVm
    {
        public int? Id { get; set; }
        [Required]
        [DisplayName("Brand Name")]
        public string Name { get; set; }
        public string Category { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}