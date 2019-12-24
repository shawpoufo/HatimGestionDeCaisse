using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;
using Dapper;

namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
     public class SqlDataAccess : ISqlDataAccess
     {
          public string GetConnectionString(string name)
          {
               return ConfigurationManager.ConnectionStrings[name].ConnectionString;
          }

          public List<T> LoadData<T, U>(string sqlQuery, U parameters, string connectionStringName)
          {
               string connectionString = GetConnectionString(connectionStringName);

               using (IDbConnection connection = new SQLiteConnection(connectionString))
               {
                    List<T> rows = connection.Query<T>(sqlQuery, parameters).ToList();
                    return rows;
               }
          }

          public void SaveData<T>(string sqlQuery, T parameters, string connectionStringName)
          {
               string connectionString = GetConnectionString(connectionStringName);

               using (IDbConnection connection = new SQLiteConnection(connectionString))
               {
                    connection.Execute(sqlQuery, parameters);

               }
          }

     }
}
