using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;
using Dapper;
using System.IO;

namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        public string RootPath { get; private set; }
        public string FolderName { get; private set; }
        public string DBName { get; private set; }

        public SqliteDataAccess()
        {
            RootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            FolderName = "CaisseUIData";
            DBName = "caisse.db";
        }
        public string GetConnectionString()
        {
             
             string dataSource = Path.Combine(RootPath, FolderName, DBName);

            return string.Format(@"Data Source = {0} ; Version = 3 ; providerName = System.Data.SqlClient",dataSource);
        }
        //Get
        public List<T> LoadData<T, U>(string sqlQuery, U parameters, string connectionStringName = "caisseCnn")
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlQuery, parameters).ToList();
                return rows;
            }
        }
        //Update , Delete , Insert
        public void SaveData<T>(string sqlQuery, T parameters, string connectionStringName = "caisseCnn")
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute(sqlQuery, parameters);

            }
        }

        public bool SignUpTransaction<T>(T parameters, string connectionStringName = "caisseCnn")
        {
            string connectionString = GetConnectionString();
            string query = "";
            bool isCreated = true;

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        query = "insert into LoginAccount (username,password,email) values (@username,@password,@email)";
                        connection.Execute(query, parameters, transaction: transaction);

                        query = "select id from LoginAccount order by id desc limit 1";
                        int id = connection.Query<int>(query, transaction: transaction).ToList().FirstOrDefault();

                        query = "insert into Compte (montant,caissier) values (@montant,@caissier)";
                        connection.Execute(query, new { montant = 0, caissier = id }, transaction: transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        isCreated = false;
                        transaction.Rollback();
                    }
                }
            }

            

            return isCreated;
        }

        
        

    }
}
