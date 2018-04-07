using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using SmartPOS.Entity.EntityModels;
using System.Configuration;
using System.Data;

namespace SmartPOS.Gateway
{
    public class CountryGateway : ConnectionGateway
    {

        public int Save(Country country)
        {
            try
            {
                Query = "Insert into tbl_Country (Country_Code,Country_Name) values ('" + country.Code + "','" + country.Name + "') ";
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

        public List<Country> GetAllCountries()
        {
            try
            {
                Query = "Select * from tbl_Country";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Country> Country = new List<Country>();
                while (Reader.Read())
                {
                    Country country = new Country()
                    {
                        Id = (int) Reader["Country_Id"],
                        Name = Reader["Country_Name"].ToString(),
                        Code = Reader["Country_Code"].ToString()
                    };

                    Country.Add(country);

                }

                Reader.Close();
                return Country;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public Country GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Country WHERE Country_Id = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Country country = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    country = new Country()
                    {
                        Id = (int)Reader["Country_Id"],
                        Name = Reader["Country_Name"].ToString(),
                        Code = Reader["Country_Code"].ToString()
                    };
                }
                Reader.Close();
                return country;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Country country)
        {
            try
            {
                Query = "UPDATE tbl_Country SET Country_Code=@Code, Country_Name=@Name WHERE Country_Id=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Code", country.Code);
                Command.Parameters.AddWithValue("Name", country.Name);
                Command.Parameters.AddWithValue("Id", country.Id);
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
