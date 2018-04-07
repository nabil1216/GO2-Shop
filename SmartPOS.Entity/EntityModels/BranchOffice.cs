using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Entity.EntityModels
{
  public  class BranchOffice
    {
        public int Id { get; set; }
      
        public string BranchName { get; set; }
    
        public string Address { get; set; }
       
        public string Phone { get; set; }
    
        public string Mobile { get; set; }
    
        public string Email { get; set; }
        public string Fax { get; set; }
        public string HeadOffices { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
