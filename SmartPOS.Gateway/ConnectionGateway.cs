using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SmartPOS.Gateway
{
  public  class ConnectionGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["SmartSHOPDB"].ConnectionString;

        public ConnectionGateway()
        {
            Connection = new SqlConnection(_connectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}
