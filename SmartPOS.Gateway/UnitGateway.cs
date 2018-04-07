using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class UnitGateway:CommonGateway
    {
        public int Save(Unit unit)
        {
            try
            {
                Query = "Insert into tbl_Unit (UnitName,CreateDate) values ('" + unit.Name + "',GETDATE()) ";
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

        public int Update(Unit unit)
        {
            try
            {
                Query = "UPDATE tbl_Unit SET UnitName=@UnitName, UpdateDate=GetDate() WHERE UnitId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("UnitName", unit.Name);
                Command.Parameters.AddWithValue("Id", unit.Id);
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

        public Unit GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Unit WHERE UnitId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Unit unit = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    unit = new Unit()
                    {
                        Id = (int)Reader["UnitId"],
                        Name = Reader["UnitName"].ToString()

                    };
                }
                Reader.Close();
                return unit;
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
