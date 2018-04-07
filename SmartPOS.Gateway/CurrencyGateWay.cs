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
 public class CurrencyGateWay: ConnectionGateway
    {
        public int Save(Currency currency)
        {
            try
            {
                Query = "Insert into tbl_Currency (Name,Sign,CreateDate) values ('" + currency.Name + "','" + currency.Sign + "',GETDATE()) ";
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

        public List<Currency> GetAllCurrencies()
        {
            try
            {
                Query = "Select * from tbl_Currency";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Currency> Currency = new List<Currency>();
                while (Reader.Read())
                {
                    Currency currency = new Currency() { 
                        Id = (int)Reader["CurrencyId"],
                        Name = Reader["Name"].ToString(),
                        Sign = Reader["Sign"].ToString()
                    };

                    Currency.Add(currency);

                }

                Reader.Close();
                return Currency;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public Currency GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Currency WHERE CurrencyId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Currency currency = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    currency = new Currency()
                    {
                        Id = (int)Reader["CurrencyId"],
                        Name = Reader["Name"].ToString(),
                        Sign = Reader["Sign"].ToString()
                    };
                }
                Reader.Close();
                return currency;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Currency currency)
        {
            try
            {
                Query = "UPDATE tbl_Currency SET Name=@Name, Sign=@Sign,UpdateDate=GetDate() WHERE CurrencyId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", currency.Name);
                Command.Parameters.AddWithValue("Sign", currency.Sign);
                Command.Parameters.AddWithValue("Id", currency.Id);
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
