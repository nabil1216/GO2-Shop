using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace SmartPOS.Gateway
{
    public class ProductGateway : ConnectionGateway
    {
        public List<Brand> FillCategory(int id)
        {

            try
            {
                // Query = "Select * From tbl_Category where BrandId=@Id";
                Query = @"SELECT c.CategoryId,b.BrandId,b.BrandName FROM tbl_Category c 
                    left outer join tbl_Brand b on c.CategoryId = b.CategoryId  where b.CategoryId= @id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                //  Category category = null;
                List<Brand> brands = new List<Brand>();


                while (Reader.Read())
                {
                    Brand brand = new Brand()
                    {
                        Id = (int)Reader["BrandId"],
                        Name = Reader["BrandName"].ToString(),
                        Category = Reader["CategoryId"].ToString()

                    };
                    brands.Add(brand);
                }

                Reader.Close();
                return brands;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(Product product)
        {
            byte[] bytes1 = null;
            byte[] bytes2 = null;
            using (BinaryReader br = new BinaryReader(product.File1.InputStream))
            {
                bytes1 = br.ReadBytes(product.File1.ContentLength);
            }
            if (product.File2 != null)
            {
                using (BinaryReader br = new BinaryReader(product.File2.InputStream))
                {
                    bytes2 = br.ReadBytes(product.File2.ContentLength);
                }
            }


            try
            {
                Query = "select count(*)from tbl_Product where ProductCode=@ProductCode";
                Command.CommandText = Query;
                Command.Parameters.AddWithValue("ProductCode", product.Code);
                Connection.Open();
                int count = (int)Command.ExecuteScalar();
                Connection.Close();
                if (count == 0)
                {

                    Query = "Insert into tbl_Product (ItemId,BrandId,CategoryId,ProductCode,Quantity,ProductName,Description,Price,Image1,Image2,CreateDate) values ('" + product.ItemId + "','" + product.BrandId + "','" + product.CategoryId + "','" + product.Code + "','" + product.Quantity + "',@ProductName,'" + product.Description + "','" + product.Price + "',@Image1,@Image2,GETDATE())";
                    Command.Parameters.AddWithValue("@ProductName", product.File1.ContentType);
                    Command.Parameters.AddWithValue("@Image1", bytes1);
                    Command.Parameters.AddWithValue("@Image2", bytes2);
                    Command.CommandText = Query;

                }

                Connection.Open();
                var rowAffected = Command.ExecuteNonQuery();
                return rowAffected;


            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Product product)
        {
            try
            {
                Query = "UPDATE tbl_Product SET ItemId=@ItemId,BrandId=@BrandId,CategoryId=@CategoryId,ProductCode=@ProductCode,Quantity=@Quantity, ProductName=@ProductName,Description=@Description,Image1=@Image1,Image2=@Image2,Price=@Price, UpdateDate=GetDate() WHERE ProductId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("ProductName", product.Name);
                Command.Parameters.AddWithValue("ItemId", product.ItemId);
                Command.Parameters.AddWithValue("BrandId", product.BrandId);
                Command.Parameters.AddWithValue("CategoryId", product.CategoryId);
                Command.Parameters.AddWithValue("ProductCode", product.Code);
                Command.Parameters.AddWithValue("Quantity", product.Quantity);

                Command.Parameters.AddWithValue("Description", product.Description);
                Command.Parameters.AddWithValue("Image1", product.file);
                Command.Parameters.AddWithValue("Image2", product.Image2);

                Command.Parameters.AddWithValue("Price", product.Price);

                Command.Parameters.AddWithValue("ProductId", product.Id);
                Connection.Open();
                int rowAffected = Command.ExecuteNonQuery();
                return rowAffected;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Product> GetAllProduct()
        {
            try
            {
                Query = @"Select ProductId,m.ItemName,b.BrandName,c.CategoryName,p.ProductCode,p.ProductName,p.Price,p.Quantity from tbl_Product p
                left outer join tbl_Item m on p.ItemId = m.ItemId
                left outer join tbl_Brand b on p.BrandId = b.BrandId
                left outer join tbl_Category c on p.CategoryId = c.CategoryId";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Product> products = new List<Product>();
                while (Reader.Read())
                {
                    Product Product = new Product()
                    {
                        Id = (int)Reader["ProductId"],
                        ItemId = Reader["ItemName"].ToString(),
                        BrandId = Reader["BrandName"].ToString(),
                        CategoryId = Reader["CategoryName"].ToString(),
                        Code = Reader["ProductCode"].ToString(),
                        Quantity = Reader["Quantity"].ToString(),
                        // Description = Reader["Description"].ToString(),
                        // Image = (Byte)Reader["Image"],
                        Name = Reader["ProductName"].ToString(),
                        Price = Reader["Price"].ToString()
                    };

                    products.Add(Product);

                }

                Reader.Close();
                return products;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }


        public Product GetById(int id)
        {
            try
            {
                Query = @"SELECT p.ProductId, p.ProductName,p.ProductCode,p.Price,b.BrandId,c.CategoryId,p.description, i.ItemId,p.Quantity from tbl_Product p 
                        left outer join tbl_Brand b on b.BrandId = p.BrandId
                        left outer join tbl_Item i on i.ItemId = p.ItemId
                        left outer join tbl_Category c on c.CategoryId = p.CategoryId WHERE p.ProductId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Product product = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    product = new Product()
                    {
                        Id = (int)Reader["ProductId"],
                        ItemId = Reader["ItemId"].ToString(),
                        BrandId = Reader["BrandId"].ToString(),
                        Name = Reader["ProductName"].ToString(),
                        CategoryId = Reader["CategoryId"].ToString(),
                        Code = Reader["ProductCode"].ToString(),
                        Description = Reader["Description"].ToString(),
                        Quantity = Reader["Quantity"].ToString(),
                        Price = Reader["Price"].ToString()


                    };
                }
                Reader.Close();
                return product;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int UpdateBarcode(Product product)
        {
            try
            {
                Query = "UPDATE tbl_Product SET Barcode=@Barcode WHERE ProductId=@ProductId";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.Add("Barcode", SqlDbType.VarBinary);
                //  Command.Parameters["Barcode"].Value = product.Barcode;
                Command.Parameters.Add("ProductId", SqlDbType.Int);
                Command.Parameters["ProductId"].Value = product.Id;
                Connection.Open();
                int rowAffected = Command.ExecuteNonQuery();
                return rowAffected;
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
