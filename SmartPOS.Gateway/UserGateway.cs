using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class UserGateway:CommonGateway
    {
        public int ValidityCheck(User user)
        {
            try
            {
                Query = @"SELECT COUNT(*) FROM tbl_SystemUser " +
                        @"WHERE [Username] = @Username AND [Password] = @Password";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Username", user.UserName);
                Command.Parameters.AddWithValue("Password", user.Password);
                Connection.Open();
                int rowAffected = (int)Command.ExecuteScalar();

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
