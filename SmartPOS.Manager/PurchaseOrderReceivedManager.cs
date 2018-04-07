using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
   public class PurchaseOrderReceivedManager
    {
        PurchaseOrderReceivedGateway purchaseOrderReceivedGateway=new PurchaseOrderReceivedGateway();

        public List<PurchaseOrder> FillPurchaseOrderReceived(int id)
        {
            return purchaseOrderReceivedGateway.FillPurchaseOrderReceived(id);
        }
    }
}
