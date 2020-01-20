using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.LoginAccountModel
{
     public class LoginAccount:ILoginAccount
     {
          public int id { get; set; }
          public string username { get; set; }
          public string password { get; set; }
          public string email { get; set; }
     }
}
