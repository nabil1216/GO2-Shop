using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using System.Configuration;
using System.Data;
namespace SmartPOS.Gateway
{
   public class CommonGateway:ConnectionGateway
    {
        public List<Common> GetAllCategories()
        {
            try
            {
                Query = "Select * from tbl_Category";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["CategoryId"],
                        Name = Reader["CategoryName"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }


        //Get All Brand

        public List<Common> GetAllBrand()
        {
            try
            {
                Query = "Select *,c.CategoryName from tbl_Brand b left outer join tbl_Category c on c.CategoryId=b.CategoryId";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common common = new Common()
                    {
                        Id = (int)Reader["BrandId"],
                        Name = Reader["BrandName"].ToString(),
                        CategoryId = Reader["CategoryName"].ToString()


                    };

                    commons.Add(common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Common> GetAllUnit()
        {
            try
            {
                Query = "Select * from tbl_Unit";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["UnitId"],
                        Name = Reader["UnitName"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Common> GetAllProduct(string prefix)
        {
            try
            {
                Query = "Select * from tbl_Product where ModelNo like '%'+@prefix+'%'";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@prefix", prefix);
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["ProductId"],
                        Name = Reader["ModelNo"].ToString(),
                        ProductName = Reader["ProductName"].ToString(),
                        Price = Reader["Price"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        //public List<Common> GetAllVat()
        //{
        //    try
        //    {
        //        Query = "Select * from tbl_Vat";
        //        Connection.Open();
        //        Command.CommandText = Query;
        //        Reader = Command.ExecuteReader();

        //        List<Common> commons = new List<Common>();
        //        while (Reader.Read())
        //        {
        //            Common Common = new Common()
        //            {
        //                Id = (int)Reader["VatId"],
        //                Name =(double) Reader["Value"]

        //            };

        //            commons.Add(Common);

        //        }

        //        Reader.Close();
        //        return commons;
        //    }
        //    finally
        //    {
        //        if (Connection != null && Connection.State != ConnectionState.Closed)
        //        {
        //            Connection.Close();
        //        }
        //    }
        //}

        public List<Common> GetAllItem()
        {
            try
            {
                Query = "Select * from tbl_Item";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["ItemId"],
                        Name = Reader["ItemName"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Common> GetAllSuppliers()
        {
            try
            {
                Query = "Select * from tbl_Supplier";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common common = new Common()
                    {
                        Id = (int)Reader["SupplierId"],
                        Name = Reader["Name"].ToString()
                        
                    };

                    commons.Add(common);

                }

                Reader.Close();
                return commons;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Common> GetAllPurchaseOrders()
        {
            try
            {
                Query = @"Select DISTINCT PO.PurcahseOrderId,PO.OrderDate,CONVERT(varchar, PO.OrderDate, 103) As OrderDate, PO.Amount,PO.PurchaseOrderNo,PO.OrderQuantity,P.ProductName,P.Price from tbl_PurchaseOrder PO 
                left outer join tbl_Product P
                    on p.ProductId = PO.ProductId";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common common = new Common()
                    {
                        Id = (int)Reader["PurcahseOrderId"],
                        Name = Reader["PurchaseOrderNo"].ToString(),
                       // OrderQuantity = Reader["OrderQuantity"].ToString(),
                       // ProductId = Reader["ProductName"].ToString(),
                       // Price = Reader["Price"].ToString(),
                       // OrderDate = Reader["OrderDate"].ToString()

                        // ProductName = Reader["ProductName"].ToString(),
                        // Price = Reader["Price"].ToString()
                    };

                    commons.Add(common);

                }

                Reader.Close();
                return commons;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }


        public List<Common> GetAllModelNo()
        {
            try
            {
                Query = @"Select PO.PurcahseOrderId,PO.OrderDate,P.ModelNo,CONVERT(varchar, PO.OrderDate, 103) As OrderDate, PO.Amount,PO.PurchaseOrderNo,PO.OrderQuantity,P.ProductName,P.Price from tbl_PurchaseOrder PO 
                left outer join tbl_Product P
                    on p.ProductId = PO.ProductId";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common common = new Common()
                    {
                        Id = (int)Reader["PurcahseOrderId"],
                        Name = Reader["ModelNo"].ToString(),
                        // OrderQuantity = Reader["OrderQuantity"].ToString(),
                        // ProductId = Reader["ProductName"].ToString(),
                        // Price = Reader["Price"].ToString(),
                        // OrderDate = Reader["OrderDate"].ToString()

                        // ProductName = Reader["ProductName"].ToString(),
                        // Price = Reader["Price"].ToString()
                    };

                    commons.Add(common);

                }

                Reader.Close();
                return commons;

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

