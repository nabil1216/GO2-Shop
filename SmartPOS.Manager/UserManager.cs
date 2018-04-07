using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class UserManager
    {
        UserGateway userGateway= new UserGateway();
        public int ValidityCheck(User model)
        {
            return userGateway.ValidityCheck(model);
        }
    }
}
