using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class BranchOfficeGateway:ConnectionGateway
    {
        public List<BranchOffice> GetAllBranches()
        {
            try
            {
                Query = "Select b.Branch_Office_Id,b.Branch_Office_Name,b.Address,b.Email,b.Mobile,h.Name from tbl_BranchOffice b Inner join tbl_HeadOffice h on b.Head_Office_Id = h.Head_Office_Id";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<BranchOffice> branchOffices = new List<BranchOffice>();
                while (Reader.Read())
                {
                    BranchOffice branchOffice = new BranchOffice()
                    {
                        Id = (int)Reader["Branch_Office_Id"],
                        BranchName = Reader["Branch_Office_Name"].ToString(),
                        Address = Reader["Address"].ToString(),
                        //   Phone = Reader["Phone"].ToString(),
                        Email = Reader["Email"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        HeadOffices = Reader["Name"].ToString()

                        //  Fax = Reader["Fax"].ToString()
                    };

                    branchOffices.Add(branchOffice);

                }

                Reader.Close();
                return branchOffices;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(BranchOffice branchOffice)
        {
            try
            {
                Query = "Insert into tbl_BranchOffice (Head_Office_Id,Branch_Office_Name,Email,Mobile,Phone,Address,Fax,CreateDate) values ('"+branchOffice.HeadOffices+"','" + branchOffice.BranchName + "','" + branchOffice.Email + "','" + branchOffice.Mobile + "','" + branchOffice.Phone + "','" + branchOffice.Address + "','" + branchOffice.Fax + "',GETDATE()) ";
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

        public int Update(BranchOffice branchOffice)
        {
            try
            {
                Query = "UPDATE tbl_BranchOffice SET Head_Office_Id=@Head_Office_Id, Branch_Office_Name=@Branch_Office_Name, Email=@Email,Phone=@Phone,Mobile=@Mobile,Address=@Address,Fax=@Fax,UpdateDate=GetDate() WHERE Branch_Office_Id=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Branch_Office_Name", branchOffice.BranchName);
                Command.Parameters.AddWithValue("Email", branchOffice.Email);
                Command.Parameters.AddWithValue("Phone", branchOffice.Phone);
                Command.Parameters.AddWithValue("Mobile", branchOffice.Mobile);
                Command.Parameters.AddWithValue("Fax", branchOffice.Fax);
                Command.Parameters.AddWithValue("Address", branchOffice.Address);
                Command.Parameters.AddWithValue("Head_Office_Id", branchOffice.HeadOffices);


                Command.Parameters.AddWithValue("Id", branchOffice.Id);
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

        public BranchOffice GetById(int id)
        {
            try
            {
                Query = "Select b.Branch_Office_Id,b.Branch_Office_Name,b.Address,b.Email,b.Phone,b.Mobile,b.Fax,h.Head_Office_Id from tbl_BranchOffice b Inner join tbl_HeadOffice h on b.Head_Office_Id = h.Head_Office_Id WHERE Branch_Office_Id = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                BranchOffice branchOffice = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    branchOffice = new BranchOffice()
                    {
                        Id = (int)Reader["Branch_Office_Id"],
                        BranchName = Reader["Branch_Office_Name"].ToString(),
                        Address = Reader["Address"].ToString(),
                        Phone = Reader["Phone"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        Email = Reader["Email"].ToString(),
                        Fax = Reader["Fax"].ToString(),
                        HeadOffices = Reader["Head_Office_Id"].ToString()
                        
                    };
                }
                Reader.Close();
                return branchOffice;
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
