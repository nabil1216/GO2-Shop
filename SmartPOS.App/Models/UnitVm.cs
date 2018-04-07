using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class UnitVm
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2)]
        [DisplayName("Unit")]
        public string Name { get; set; }

    }
}