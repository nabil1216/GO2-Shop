using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
   public class CategoryManager
    {
        CategoryGateway categoryGateway=new CategoryGateway();

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public String Save(Category category)
        {
            int rowAfftected = categoryGateway.Save(category);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public Category GetById(int id)
        {
            return categoryGateway.GetById(id);
        }

        public string Update(Category category)
        {
            int rowAfftected = categoryGateway.Update(category);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }
    }
}
