using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class CurrencyVm
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sign { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}