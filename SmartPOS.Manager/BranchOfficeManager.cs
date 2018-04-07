using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
 public  class BranchOfficeManager
    {
        BranchOfficeGateway branchOfficeGateway= new BranchOfficeGateway();
        public List<BranchOffice> GetAllBranches()
        {
            return branchOfficeGateway.GetAllBranches();
        }

        public String Save(BranchOffice branchOffice)
        {
            int rowAfftected = branchOfficeGateway.Save(branchOffice);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public BranchOffice GetById(int id)
        {
            return branchOfficeGateway.GetById(id);
        }

        public string Update(BranchOffice branchOffice)
        {
            int rowAfftected = branchOfficeGateway.Update(branchOffice);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }
    }
}
