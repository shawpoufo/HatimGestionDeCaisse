using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.AccountDataAccess
{
    public class AccountData : CaisseLogicLibrary.DataAccess.AccountDataAccess.IAccountData
    {
        private ISqliteDataAccess _sqliteDataAccess;
        public AccountData(ISqliteDataAccess sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess;
        }

        public decimal Amount(int id)
        {

            string query = "select montant from Compte where id = @id";
            
            return _sqliteDataAccess.LoadData<decimal,dynamic>(query, new { id = id }).FirstOrDefault();
        }
    }
}
