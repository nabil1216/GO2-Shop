using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
 public class CurrencyManager
    {
        CurrencyGateWay currencyGateWay=new CurrencyGateWay();

        public  String Save(Currency currency)
        {
            int rowAfftected = currencyGateWay.Save(currency);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public List<Currency> GetAllCurrencies()
        {
            return currencyGateWay.GetAllCurrencies();
        }

        public Currency GetById(int id)
        {
            return currencyGateWay.GetById(id);
        }

        public string Update(Currency currency)
        {
            int rowAfftected = currencyGateWay.Update(currency);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }
    }
}
