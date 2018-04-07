using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class BankManager
    {
        BankGateway bankGateway=new BankGateway();

        public List<Bank> GetAllBank()
        {
            return bankGateway.GetAllBank();
        }

        public String Save(Bank bank)
        {
            int rowAfftected = bankGateway.Save(bank);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public Bank GetById(int id)
        {
            return bankGateway.GetById(id);
        }

        public string Update(Bank bank)
        {
            int rowAfftected = bankGateway.Update(bank);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }


    }
}
