using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class PurchaseOrderReceivedGateway:CommonGateway
    {
        public List<PurchaseOrder> FillPurchaseOrderReceived(int id)
        {
            try
            {
                // Query = "Select * From tbl_Category where BrandId=@Id";
                Query = @"SELECT PO.PurchaseOrderNo,PO.ProductId,P.ModelNo,PO.PurcahseOrderId FROM tbl_PurchaseOrder PO             
				left outer join tbl_Product P on P.ProductId=PO.ProductId where PO.PurcahseOrderId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                //  Category category = null;
                List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();


                while (Reader.Read())
                {
                    PurchaseOrder purchaseOrder = new PurchaseOrder()
                    {
                        Id = (int)Reader["PurcahseOrderId"],
                         ModelNo= Reader["ModelNo"].ToString(),
                        OrderNo = Reader["PurchaseOrderNo"].ToString()

                    };
                    purchaseOrders.Add(purchaseOrder);
                }

                Reader.Close();
                return purchaseOrders;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }
    }
}
