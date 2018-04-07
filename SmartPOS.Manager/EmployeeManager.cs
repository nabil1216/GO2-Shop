using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class EmployeeManager
    {
        EmployeeGateway employeeGateway= new EmployeeGateway();
        public List<Employee> GetAllEmployees()
        {
            return employeeGateway.GetAllEmployees();
        }

        public String Save(Employee employee)
        {
            int rowAfftected = employeeGateway.Save(employee);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public string Update(Employee employee)
        {
            int rowAfftected = employeeGateway.Update(employee);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public Employee GetById(int id)
        {
            return employeeGateway.GetById(id);
        }
    }
}
