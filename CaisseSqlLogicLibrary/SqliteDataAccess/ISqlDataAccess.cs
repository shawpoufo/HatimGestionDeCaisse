using System;
namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
     public interface ISqlDataAccess
     {
          string GetConnectionString(string name);
          System.Collections.Generic.List<T> LoadData<T, U>(string sqlQuery, U parameters, string connectionStringName);
          void SaveData<T>(string sqlQuery, T parameters, string connectionStringName);
     }
}
