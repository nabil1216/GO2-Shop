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
   public class SupplierGateway: ConnectionGateway
    {
        public List<Supplier> GetAllSuppliers()
        {
            try
            {
                Query = "Select * from tbl_Supplier";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Supplier> suppliers = new List<Supplier>();
                while (Reader.Read())
                {
                    Supplier supplier = new Supplier()
                    {
                        Id = (int)Reader["SupplierId"],
                        Name = Reader["Name"].ToString(),
                        Address = Reader["Address"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        Fax = Reader["Fax"].ToString()
                    };

                    suppliers.Add(supplier);

                }

                Reader.Close();
                return suppliers;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(Supplier supplier)
        {
            try
            {
                Query = "Insert into tbl_Supplier (Name,Address,Mobile,Fax,CreateDate) values ('" + supplier.Name + "','"+supplier.Address+"','"+supplier.Mobile+"','"+supplier.Fax+"',GETDATE()) ";
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

        public Supplier GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Supplier WHERE SupplierId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Supplier supplier = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    supplier = new Supplier()
                    {
                        Id = (int)Reader["SupplierId"],
                        Name = Reader["Name"].ToString(),
                        Address = Reader["Address"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        Fax = Reader["Fax"].ToString()
                    };
                }
                Reader.Close();
                return supplier;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Supplier supplier)
        {
            try
            {
                Query = "UPDATE tbl_Supplier SET Name=@Name,Address=@Address,Mobile=@Mobile,Fax=@Fax, UpdateDate=GetDate() WHERE SupplierId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", supplier.Name);
                Command.Parameters.AddWithValue("Address", supplier.Address);
                Command.Parameters.AddWithValue("Mobile", supplier.Mobile);
                Command.Parameters.AddWithValue("Tax", supplier.Fax);
                Command.Parameters.AddWithValue("Id", supplier.Id);
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
