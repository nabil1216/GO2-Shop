using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
   public class VatGateway:ConnectionGateway
    {
        public int Save(Vat vat)
        {
            try
            {
                Query = "Insert into tbl_Vat (Value,CreateDate) values ('" + vat.Value + "',GETDATE()) ";
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

        public Vat GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Vat WHERE VatId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Vat vat = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    vat = new Vat()
                    {
                        Id = (int)Reader["VatId"],
                        Value =(double) Reader["Value"]

                    };
                }
                Reader.Close();
                return vat;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Vat vat)
        {
            try
            {
                Query = "UPDATE tbl_Vat SET Value=@Value, UpdateDate=GetDate() WHERE VatId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Value", vat.Value);
                Command.Parameters.AddWithValue("Id", vat.Id);
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
        public List<Vat> GetAllVat()
        {
            try
            {
                Query = "Select * from tbl_Vat";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Vat> vats = new List<Vat>();
                while (Reader.Read())
                {
                    Vat vat = new Vat()
                    {
                        Id = (int)Reader["VatId"],
                         Value= (double)Reader["Value"]

                    };

                    vats.Add(vat);

                }

                Reader.Close();
                return vats;
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
