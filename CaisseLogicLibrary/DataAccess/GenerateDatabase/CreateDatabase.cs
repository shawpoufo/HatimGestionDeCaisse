using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CaisseSqlLogicLibrary;


namespace CaisseLogicLibrary.DataAccess.GenerateDatabase
{
    public class CreateDatabase : CaisseLogicLibrary.DataAccess.GenerateDatabase.ICreateDatabase
    {
        private IDatabaseGenerator _databaseGenerator;
        public CreateDatabase(IDatabaseGenerator databaseGenerator)
        {
            _databaseGenerator = databaseGenerator;
        }
        public void Create()
        {
            _databaseGenerator.GenerateDatabase();
        }
    }
}
