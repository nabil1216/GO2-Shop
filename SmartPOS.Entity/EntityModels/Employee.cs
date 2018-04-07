using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Entity.EntityModels
{
  public  class Employee
    {
        public int Id;
        public string Name;
        public string Address;
        public string Mobile;
        public string EmergrncyContact;
        public DateTime JoiningDate;
        public string NID;
        public double BasicSalary;
        public string CardNo;
        //   public byte[] Image;
        public DateTime CreateDate;
        public DateTime UPdateDate;
    }
}
