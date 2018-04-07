using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class StoreVm
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(maximumLength: 15, MinimumLength = 11, ErrorMessage = "Phone number minimum length of 11 digit")]
        public string Phone { get; set; }
        [StringLength(25)]
        public string Address { get; set; }
    }
}