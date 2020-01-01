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
     public class SqliteDataAccess : ISqliteDataAccess
     {
          public string GetConnectionString(string name)
          {
               //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
               return @"Data Source=C:\Users\AND\Desktop\Projet Caisse WinForm\HatimGestionDeCaisse\CaisseWinformUI\bin\Debug\caisse.db;Version=3; providerName=System.Data.SqlClient";
          }
          //Get
          public List<T> LoadData<T,U>(string sqlQuery, U parameters, string connectionStringName)
          {
               string connectionString = GetConnectionString(connectionStringName);

               using (IDbConnection connection = new SQLiteConnection(connectionString))
               {
                    List<T> rows = connection.Query<T>(sqlQuery, parameters).ToList();
                    return rows;
               }
          }
          //Update , Delete , Insert
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
