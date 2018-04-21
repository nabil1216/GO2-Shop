using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using System.Data;

namespace SmartPOS.Gateway
{
    public class DiscountGateway : CommonGateway
    {
        public List<Discount> GetAllDiscount()
        {
            try
            {
                Query = "Select * from tbl_Discount";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Discount> Discount = new List<Discount>();
                while (Reader.Read())
                {
                    Discount discount = new Discount()
                    {
                        Id = (int)Reader["DiscountTypeId"],
                        Name = Reader["DiscountTypeName"].ToString(),
                        

                    };

                    Discount.Add(discount);

                }

                Reader.Close();
                return Discount;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(Discount discount)
        {
            try
            {
                Query = "Insert into tbl_Discount (DiscountTypeName) values ('" + discount.Name+ "') ";
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

        public int Update(Discount discount)
        {
            try
            {
                Query = "UPDATE tbl_Discount SET DiscountTypeName=@Name WHERE DiscountTypeId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", discount.Name);
                Command.Parameters.AddWithValue("Id", discount.Id);
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

        public Discount GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Discount WHERE DiscountTypeId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Discount discount = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    discount = new Discount()
                    {
                        Id = (int)Reader["DiscountTypeId"],
                        Name = Reader["DiscountTypeName"].ToString()

                    };
                }
                Reader.Close();
                return discount;
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
