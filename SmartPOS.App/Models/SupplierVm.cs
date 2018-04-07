using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace SmartPOS.App.Models
{
    public class SupplierVm
    {
        public int? Id { get; set; }
        [Required (ErrorMessage = "Provide Supplier Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide Supplier Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Provide Supplier Phone no.")]
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}