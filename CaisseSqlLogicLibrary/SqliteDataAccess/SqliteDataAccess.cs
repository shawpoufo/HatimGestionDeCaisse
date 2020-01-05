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
        public List<T> LoadData<T, U>(string sqlQuery, U parameters, string connectionStringName = "caisseCnn")
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlQuery, parameters).ToList();
                return rows;
            }
        }
        //Update , Delete , Insert
        public void SaveData<T>(string sqlQuery, T parameters, string connectionStringName = "caisseCnn")
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute(sqlQuery, parameters);

            }
        }

        public bool SignUpTransaction<T>(T parameters, string connectionStringName = "caisseCnn")
        {
            string connectionString = GetConnectionString(connectionStringName);
            string query = "";
            bool isCreated = false;

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        query = "insert into LoginAccount (username,password) values (@username,@password)";
                        connection.Execute(query, parameters);

                        query = "select top 1 id from LoginAccount order by id desc ";
                        int id = connection.Query<int>(query).ToList().FirstOrDefault();

                        query = "insert into Compte (montant,caissier) values (@montant,@caissier)";
                        connection.Execute(query, new { montant = 0, caissier = id });

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            isCreated = true;

            return isCreated;
        }

    }
}
