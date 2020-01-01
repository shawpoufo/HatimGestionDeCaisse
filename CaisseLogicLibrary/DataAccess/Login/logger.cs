using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using Dapper;
using System.Data;
using CaisseDTOsLibrary.Models.LoginAccountModel;

namespace CaisseLogicLibrary.DataAccess.Login
{
     public class Logger
     {
          private ISqliteDataAccess _sqlDataAccess;
          private ILoginAccount _loginAccount;

          public Logger(ISqliteDataAccess sqlDataAccess ,ILoginAccount loginAccount)
          {
               _sqlDataAccess = sqlDataAccess;
               _loginAccount = loginAccount;
          }

          public int Login()
          {
               string query = "select count(id) from LoginAccount where username = @username and password = @password ";

               var output = _sqlDataAccess.LoadData<LoginAccount,dynamic>(query, _loginAccount, "caisseCnn").FirstOrDefault();

               if (output != null)
                    return output.id;
               else
                    return 0;
          }

     }
}
