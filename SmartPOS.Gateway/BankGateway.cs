using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
   public class BankGateway:ConnectionGateway
    {
        public List<Bank> GetAllBank()
        {
            try
            {
                Query = "Select * from tbl_Bank";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Bank> Bank = new List<Bank>();
                while (Reader.Read())
                {
                    Bank bank = new Bank()
                    {
                        Id = (int)Reader["BankId"],
                        Name = Reader["Name"].ToString(),
                        AccNo = Reader["AccNo"].ToString(),
                        Phone = Reader["Phone"].ToString(),
                        Address = Reader["Address"].ToString()

                    };

                    Bank.Add(bank);

                }

                Reader.Close();
                return Bank;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(Bank bank)
        {
            try
            {
                Query = "Insert into tbl_bank (Name,AccNo,Phone,Address) values ('" + bank.Name + "','" + bank.AccNo + "','"+bank.Phone+"','"+bank.Address+"') ";
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

        public Bank GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Bank WHERE BankId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Bank bank = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    bank = new Bank()
                    {
                        Id = (int)Reader["BankId"],
                        Name = Reader["Name"].ToString(),
                        AccNo = Reader["AccNo"].ToString(),
                        Address = Reader["Address"].ToString()

                    };
                }
                Reader.Close();
                return bank;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Bank bank)
        {
            try
            {
                Query = "UPDATE tbl_Bank SET Name=@Name, AccNo=@AccNo,Phone=@Phone,Address=@Address WHERE BankId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", bank.Name);
                Command.Parameters.AddWithValue("AccNo", bank.AccNo);
                Command.Parameters.AddWithValue("Phone", bank.Phone);
                Command.Parameters.AddWithValue("Address", bank.Address);
                Command.Parameters.AddWithValue("Id", bank.Id);
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
