using CaisseDTOsLibrary.Models.OperationModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.OperationDataAccess
{
    public class OperationData : CaisseLogicLibrary.DataAccess.OperationDataAccess.IOperationData
    {
        private ISqliteDataAccess _sqliteDataAccess;
        private string query { get; set; }

        public OperationData(ISqliteDataAccess sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess;
        }

        public void Insert(Operation operation)
        {
            query = "insert into Operation "+
                    "(date,imputation,incrementer,decrementer,beneficiaire,libelle,compte) "+
                    "values (@date,@imputation,@incrementer,@decrementer,@beneficiaire,@libelle,@compte) ";
            _sqliteDataAccess.SaveData<Operation>(query, operation);
        }

        public void Update(Operation operation)
        {
            query = "update Operation set "+
                    "date = @date , imputation = @imputation, "+
                    "incrementer = @incrementer , decrementer = @decrementer, " +
                    "beneficiaire = @beneficiaire , libelle = @libelle, " +
                    "compte = @compte " +
                    "where id = @id";

            _sqliteDataAccess.SaveData<Operation>(query, operation);
        }

        public void Delete(int id)
        {
            query = "delete from Operation where id = @id";
            _sqliteDataAccess.SaveData<dynamic>(query, new { id = id });
        }
        public IOperation Get(int id)
        {
            query = "select * from Operation where id = @id";
            return _sqliteDataAccess.LoadData<Operation,dynamic>(query, new { id = id }).FirstOrDefault();
        }

    }
}
