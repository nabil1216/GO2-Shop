using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;
namespace SmartPOS.Manager
{
  public  class CountryManager
    {
        CountryGateway countryGateway = new CountryGateway();
        
        public String Save(Country country)
        {
            int rowAfftected = countryGateway.Save(country);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public List<Country> GetAllCountries()
        {
            return countryGateway.GetAllCountries();
        }

        public Country GetById(int id)
        {
            return countryGateway.GetById(id);
        }

        public string Update(Country country)
        {
            int rowAfftected = countryGateway.Update(country);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

    }
}
