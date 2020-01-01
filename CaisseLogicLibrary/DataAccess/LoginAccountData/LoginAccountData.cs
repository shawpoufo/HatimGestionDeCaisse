using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.LoginAccountData
{
     public class LoginAccountData
     {
          private ISqliteDataAccess _sqlDataAccess;

          public LoginAccountData(ISqliteDataAccess sqlDataAccess)
          {
               _sqlDataAccess = sqlDataAccess;
          }

          
     }
}
