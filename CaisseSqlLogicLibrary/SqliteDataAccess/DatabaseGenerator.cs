using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
    public class DatabaseGenerator : CaisseSqlLogicLibrary.SqliteDataAccess.IDatabaseGenerator
    {

        private ISqliteDataAccess _sqlDataAccess;
        public DatabaseGenerator(ISqliteDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public void GenerateDatabase()
        {
            if (!Directory.Exists(Path.Combine(_sqlDataAccess.RootPath, _sqlDataAccess.FolderName)))
            {
                CreateDBFolder(_sqlDataAccess.RootPath, _sqlDataAccess.FolderName);
            }

            CreateDatabase(_sqlDataAccess.RootPath, _sqlDataAccess.DBName);
            CreateTables(_sqlDataAccess.GetConnectionString());
        }
        private void CreateDBFolder(string rootPath, string folderName)
        {
            Directory.CreateDirectory(Path.Combine(rootPath, folderName));
        }
        private void CreateDatabase(string rootPath, string dbName)
        {
            var fileInfo = new FileInfo(Path.Combine(rootPath, dbName + ".db"));
            if(!fileInfo.Exists)
                SQLiteConnection.CreateFile(Path.Combine(rootPath, dbName + ".db"));
        }
        private void CreateTables(string strConnection)
        {
            List<string> tablesQuerys = new List<string>();
            tablesQuerys.Add("Create table IF NOT EXISTS LoginAccount ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, username TEXT NOT NULL UNIQUE, password	TEXT NOT NULL, email TEXT NOT NULL UNIQUE );");
            tablesQuerys.Add("Create table IF NOT EXISTS Compte ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, montant REAL NOT NULL ,caissier INTEGER NOT NULL, FOREIGN KEY(caissier) REFERENCES LoginAccount(id) );");
            tablesQuerys.Add("Create table IF NOT EXISTS Imputation ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, libelle TEXT NOT NULL UNIQUE, compte INTEGER NOT NULL, FOREIGN KEY(compte) REFERENCES Compte(id) );");
            tablesQuerys.Add("Create table IF NOT EXISTS Beneficiaire ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, libelle TEXT NOT NULL UNIQUE , compte INTEGER NOT NULL, FOREIGN KEY(compte) REFERENCES Compte(id) );");
            tablesQuerys.Add("Create table IF NOT EXISTS Operation ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, date TEXT NOT NULL, imputation INTEGER, incrementer REAL, decrementer REAL, beneficiaire INTEGER, libelle TEXT NOT NULL, compte INTEGER NOT NULL, " +
                                " FOREIGN KEY(compte) REFERENCES Compte(id), FOREIGN KEY(beneficiaire) REFERENCES Beneficiaire(id) ON DELETE SET NULL, FOREIGN KEY(imputation) REFERENCES Imputation(id) ON DELETE SET NULL );");

            using (SQLiteConnection dbConnection = new SQLiteConnection(strConnection))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (var query in tablesQuerys)
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch 
                    {

                        transaction.Rollback();
                    }
                }
            }
            
        }
    }
}
