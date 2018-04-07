using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
   public class HeadOfficeGateway: ConnectionGateway
    {
        public List<HeadOffice> GetAllHeadOffice()
        {
            try
            {
                Query = "Select * from tbl_HeadOffice";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<HeadOffice> headOffices = new List<HeadOffice>();
                while (Reader.Read())
                {
                    HeadOffice headOffice = new HeadOffice()
                    {
                        Id = (int)Reader["Head_Office_Id"],
                        Name = Reader["Name"].ToString(),
                        Address = Reader["Address"].ToString(),
                        //   Phone = Reader["Phone"].ToString(),
                        Email = Reader["Email"].ToString(),
                        Mobile = Reader["Mobile"].ToString()
                   
                      //  Fax = Reader["Fax"].ToString()
                    };

                    headOffices.Add(headOffice);

                }

                Reader.Close();
                return headOffices;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(HeadOffice headOffice)
        {
            try
            {
                Query = "Insert into tbl_HeadOffice (Name,Email,Phone,Mobile,Address,Fax,CreateDate) values ('" + headOffice.Name + "','" + headOffice.Email + "','"+headOffice.Phone+ "','" + headOffice.Mobile + "','" + headOffice.Address + "','" + headOffice.Fax + "',GETDATE()) ";
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

        public int Update(HeadOffice headOffice)
        {
            try
            {
                Query = "UPDATE tbl_HeadOffice SET Name=@Name, Email=@Email,Phone=@Phone,Mobile=@Mobile,Address=@Address,Fax=@Fax,UpdateDate=GetDate() WHERE Head_Office_Id=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", headOffice.Name);
                Command.Parameters.AddWithValue("Email", headOffice.Email);
                Command.Parameters.AddWithValue("Phone", headOffice.Phone);
                Command.Parameters.AddWithValue("Mobile", headOffice.Mobile);
                Command.Parameters.AddWithValue("Fax", headOffice.Fax);
                Command.Parameters.AddWithValue("Address", headOffice.Address);
                Command.Parameters.AddWithValue("Id", headOffice.Id);
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

        public HeadOffice GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Headoffice WHERE Head_Office_Id = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                HeadOffice headOffice = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    headOffice = new HeadOffice()
                    {
                        Id = (int)Reader["Head_Office_Id"],
                        Name = Reader["Name"].ToString(),
                        Address = Reader["Address"].ToString(),
                        Phone = Reader["Phone"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        Email = Reader["Email"].ToString(),
                        Fax = Reader["Fax"].ToString()
                    };
                }
                Reader.Close();
                return headOffice;
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
