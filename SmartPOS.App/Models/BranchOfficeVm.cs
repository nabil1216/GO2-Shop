using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace SmartPOS.App.Models
{
    public class BranchOfficeVm
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Provide Name here")]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "Provide Address here")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Provide Phone no here")]
        public string Phone { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Provide Email address here")]
        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Provide Valid Email Address")]
        public string Email { get; set; }
        public string Fax { get; set; }
        [Display(Name = "Head Office")]
        public string HeadOffices { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}