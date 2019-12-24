using CaisseDTOsLibrary.Models.User;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.User
{
     public class UserData
     {
          private ISqlDataAccess _sqlDataAccess;

          public UserData(ISqlDataAccess sqlDataAccess)
          {
               _sqlDataAccess = sqlDataAccess;
          }

          public void LogIn()
          {
                 
          }
     }
}
