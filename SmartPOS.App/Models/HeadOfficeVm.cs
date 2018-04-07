using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SmartPOS.App.Models
{
    public class HeadOfficeVm
    {
        public int? Id { get; set; }
        [Required (ErrorMessage = "Provide Name here")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Provide Address here")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Provide Phone no here")]
        public string Phone { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Provide Email address here")]
       
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "Provide Valid Email Address")]
        public string Email { get; set; }
        public string Fax { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}