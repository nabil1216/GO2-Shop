using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class EmployeeGateway:CommonGateway
    {
        public List<Employee> GetAllEmployees()
        {
            try
            {
                Query = "SELECT * FROM tbl_Employee";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Employee> employees = new List<Employee>();
                while (Reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        Id = (int)Reader["EmployeeId"],

                        Name = Reader["EmployeeName"].ToString(),
                        Address = Reader["Address"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        EmergrncyContact = Reader["EmergencyContact"].ToString(),
                        JoiningDate =(DateTime) Reader["JoiningDate"],
                        NID = Reader["NID"].ToString(),
                        BasicSalary =Convert.ToDouble(Reader["BasicSalary"]) ,
                        CardNo = Reader["CardNo"].ToString()
                        
                    };

                    employees.Add(employee);

                }

                Reader.Close();
                return employees;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Save(Employee employee)
        {
            try
            {
                Query = "Insert into tbl_Employee (EmployeeName,Address,Mobile,EmergencyContact,JoiningDate,NID,BasicSalary,CardNo,CreateDate) values ('" + employee.Name + "','" + employee.Address + "','" + employee.Mobile + "','" + employee.EmergrncyContact + "','" + employee.JoiningDate + "','" + employee.NID + "','" + employee.BasicSalary + "','" + employee.CardNo + "',GETDATE()) ";
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

        public int Update(Employee employee)
        {
            try
            {
                Query = "UPDATE tbl_Employee SET EmployeeName=@EmployeeName,Address=@Address,Mobile=@Mobile,EmergencyContact=@EmergencyContact,JoiningDate=@JoiningDate,NID=@NID,BasicSalary=@BasicSalary,CardNo=@CardNo, UpdateDate=GetDate() WHERE EmployeeId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("EmployeeName", employee.Name);
                Command.Parameters.AddWithValue("Address", employee.Address);
                Command.Parameters.AddWithValue("Mobile", employee.Mobile);
                Command.Parameters.AddWithValue("EmergencyContact", employee.EmergrncyContact);
                Command.Parameters.AddWithValue("JoiningDate", employee.JoiningDate);
                Command.Parameters.AddWithValue("NID", employee.NID);
                Command.Parameters.AddWithValue("BasicSalary", employee.BasicSalary);
                Command.Parameters.AddWithValue("CardNo", employee.CardNo);
                Command.Parameters.AddWithValue("Id", employee.Id);
              
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

        public Employee GetById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_Employee WHERE EmployeeId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Employee employee = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    employee = new Employee()
                    {
                        Id = (int)Reader["EmployeeId"],

                        Name = Reader["EmployeeName"].ToString(),
                        Address = Reader["Address"].ToString(),
                        Mobile = Reader["Mobile"].ToString(),
                        EmergrncyContact = Reader["EmergencyContact"].ToString(),
                        JoiningDate = (DateTime)Reader["JoiningDate"],
                        NID = Reader["NID"].ToString(),
                        BasicSalary = Convert.ToDouble(Reader["BasicSalary"]),
                        CardNo = Reader["CardNo"].ToString()

                    };
                }
                Reader.Close();
                return employee;
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
