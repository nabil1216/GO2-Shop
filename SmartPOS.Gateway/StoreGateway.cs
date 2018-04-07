using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class StoreGateway:CommonGateway
    {
        public List<Store> GetAllStore()
        {
            try
            {
                Query = "Select * from tbl_Store";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Store> Store = new List<Store>();
                while (Reader.Read())
                {
                    Store store = new Store()
                    {
                        Id = (int)Reader["StoreId"],
                        Name = Reader["StoreName"].ToString(),
                        Phone = Reader["Phone"].ToString(),
                        Address = Reader["Address"].ToString()

                    };

                    Store.Add(store);

                }

                Reader.Close();
                return Store;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(Store store)
        {
            try
            {
                Query = "Insert into tbl_Store (StoreName,Phone,Address) values ('" + store.Name + "','" + store.Phone + "','" + store.Address + "') ";
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

        public int Update(Store store)
        {
            try
            {
                Query = "UPDATE tbl_Store SET StoreName=@StoreName, Phone=@Phone,Address=@Address WHERE StoreId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("StoreName", store.Name);
            
                Command.Parameters.AddWithValue("Phone", store.Phone);
                Command.Parameters.AddWithValue("Address", store.Address);
                Command.Parameters.AddWithValue("Id", store.Id);
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

        public Store GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Store WHERE StoreId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Store store = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    store = new Store()
                    {
                        Id = (int)Reader["StoreId"],
                        Name = Reader["StoreName"].ToString(),
                        Phone = Reader["Phone"].ToString(),
                        Address = Reader["Address"].ToString()

                    };
                }
                Reader.Close();
                return store;
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
