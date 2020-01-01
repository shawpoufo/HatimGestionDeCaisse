using Dapper;
using System;
using System.Collections.Generic;
namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
     public interface ISqliteDataAccess
     {
          string GetConnectionString(string name);
          List<T> LoadData<T, U>(string sqlQuery, U parameters, string connectionStringName);
          void SaveData<T>(string sqlQuery, T parameters, string connectionStringName);
     }
}
