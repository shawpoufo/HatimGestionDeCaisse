using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using CaisseDTOsLibrary.Models.User;

namespace CaisseLogicLibrary.DataAccess.Login
{
     public class logger
     {
          private ISqlDataAccess _sqlDataAccess;
          private IPersonne _personne;

          public logger(ISqlDataAccess sqlDataAccess ,IPersonne personne)
          {
               _sqlDataAccess = sqlDataAccess;
               _personne = personne;
          }

          public bool Login()
          {
               string query = "select count(id) from Login where username = @username and password = @password ";

               var p = new
               {
                    username = _personne.username,
                    password = _personne.password
               };

               var output = _sqlDataAccess.LoadData<Personne, dynamic>(query, p, "caisseCnn");

               return Convert.ToBoolean(output);
          }
     }
}
