using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class BrandGateway: ConnectionGateway
    {
        public int Save(Brand brand)
        {
            try
            {
                Query = "Insert into tbl_Brand (BrandName,CategoryId,CreateDate) values ('" + brand.Name + "','"+brand.Category+"',GETDATE()) ";
                Command.CommandText = Query;
                Connection.Open();
                int rowAfftected = Command.ExecuteNonQuery();
                return rowAfftected;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public Brand GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Brand WHERE BrandId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Brand brand = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    brand = new Brand()
                    {
                        Id = (int)Reader["BrandId"],
                        Name = Reader["BrandName"].ToString(),
                        Category = Reader["CategoryId"].ToString()

                    };
                }
                Reader.Close();
                return brand;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Brand brand)
        {
            try
            {
                Query = "UPDATE tbl_Brand SET BrandName=@Name,CategoryId=@CategoryId, UpdateDate=GetDate() WHERE BrandId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", brand.Name);
                Command.Parameters.AddWithValue("Id", brand.Id);
                Command.Parameters.AddWithValue("CategoryId", brand.Category);
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
