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
     public class Logger : CaisseLogicLibrary.DataAccess.Login.ILogger
     {
          private ISqliteDataAccess _sqlDataAccess;


          public Logger(ISqliteDataAccess sqlDataAccess )
          {
               _sqlDataAccess = sqlDataAccess;

          }

          public int Login(ILoginAccount user)
          {
               string query = "select id from LoginAccount where username = @username and password = @password ";
               var output = _sqlDataAccess.LoadData<LoginAccount, dynamic>(query, user, "caisseCnn").FirstOrDefault();

               if (output != null)
                    return output.id;
               else
                    return 0;
          }

     }
}
