using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.SignUp
{
     public class SignUpUser : CaisseLogicLibrary.DataAccess.SignUp.ISignUpUser
     {
          private ISqliteDataAccess _sqlDataAccess;

          public SignUpUser(ISqliteDataAccess sqlDataAccess)
          {
               _sqlDataAccess = sqlDataAccess;
          }

          public bool SignUp(ILoginAccount user)
          {
              return _sqlDataAccess.SignUpTransaction<LoginAccount>((LoginAccount)user);
          }

          
     }
}
