using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System.IO;

namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
    public class SqliteTransaction : CaisseSqlLogicLibrary.SqliteDataAccess.ISqliteTransaction, IDisposable
    {
        public string GetConnectionString()
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderName = "CaisseUIData";
            string dbName = "caisse.db";
            string dataSource = Path.Combine(rootPath, folderName, dbName);

            return string.Format(@"Data Source = {0} ; Version = 3 ; providerName = System.Data.SqlClient", dataSource);
        }
        private IDbConnection _connection;
        private IDbTransaction _transacion;
        private bool isClosed = false;

        public void StartTransaction()
        {
            string connectionString = GetConnectionString();

            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
            _transacion = _connection.BeginTransaction();

            isClosed = false;
        }
        public void ComitTransaction()
        {
            if (_transacion != null) _transacion.Commit();
            if (_connection != null) _connection.Close();

            isClosed = true;
        }

        public void RollBackTransaction()
        {
            if (_transacion != null) _transacion.Rollback();
            if (_connection != null) _connection.Close();

            isClosed = true;
        }

        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    ComitTransaction();
                }
                catch
                {

                    //TODO - Log this issue
                }
            }

            _transacion = null;
            _connection = null;
        }
        public void SavedDataInTransaction<T>(T parameters, string query)
        {
            _connection.Execute(query, parameters, transaction: _transacion);
        }

        public List<T> LoadDataInTransaction<T, U>(U parameters, string query)
        {

            List<T> rows = _connection.Query<T>(query, parameters, transaction: _transacion).ToList();
            return rows;
        }
    }
}
