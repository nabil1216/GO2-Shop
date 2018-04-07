using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class EmployeeVm
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Mobile { get; set; }
        [DisplayName("Emergency Contact")]
        public string EmergrncyContact { get; set; }
        [DisplayName("Joining Date")]
        [DataType(DataType.Date)]
        public DateTime? JoiningDate { get; set; }
        [Required]
        public string NID { get; set; }
        [DisplayName("Basic Salary")]
        public double BasicSalary { get; set; }
        [DisplayName("Card No")]
        public string CardNo { get; set; }
        //   public byte[] Image;
        public DateTime CreateDate { get; set; }
        public DateTime UPdateDate { get; set; }
    }
}