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
   public class ItemGateway: ConnectionGateway
    {
        public int Save(Item item)
        {
            try
            {
                Query = "Insert into tbl_Item (ItemName,CreateDate) values ('" + item.Name + "',GETDATE()) ";
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

        public List<Item> GetAllMaterialTypes()
        {
            try
            {
                Query = "Select * from tbl_Item";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Item> Items = new List<Item>();
                while (Reader.Read())
                {
                    Item item = new Item()
                    {
                        Id = (int)Reader["ItemId"],
                        Name = Reader["ItemName"].ToString()
                       
                    };

                    Items.Add(item);

                }

                Reader.Close();
                return Items;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Item item)
        {
            try
            {
                Query = "UPDATE tbl_Item SET ItemName=@ItemName,UpdateDate=GetDate() WHERE ItemId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("ItemName", item.Name);
               
                Command.Parameters.AddWithValue("Id", item.Id);
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

        public Item GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Item WHERE ItemId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Item item = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    item = new Item()
                    {
                        Id = (int)Reader["ItemId"],
                        Name = Reader["ItemName"].ToString()
                      
                    };
                }
                Reader.Close();
                return item;
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
