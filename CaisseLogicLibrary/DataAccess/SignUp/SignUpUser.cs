using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.SignUp
{
     public class SignUpUser
     {
          private ISqliteDataAccess _sqlDataAccess;

          public SignUpUser(ISqliteDataAccess sqlDataAccess)
          {
               _sqlDataAccess = sqlDataAccess;
          }

          public bool SignUp(LoginAccount user)
          {
              return _sqlDataAccess.SignUpTransaction<LoginAccount>(user);
          }

          
     }
}
