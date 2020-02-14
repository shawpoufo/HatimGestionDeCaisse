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

        public void Insert(Operation operation,decimal newAmount)
        {
            using (SqliteTransaction sql = new SqliteTransaction())
            {
                try
                {
                    sql.StartTransaction();
                    query = "insert into Operation " +
                        "(date,imputation,incrementer,decrementer,beneficiaire,libelle,compte) " +
                        "values (@date,@imputation,@incrementer,@decrementer,@beneficiaire,@libelle,@compte) ";
                    sql.SavedDataInTransaction<Operation>(operation, query);

                    query = "update Compte set montant = @newAmount where id = @id";

                    sql.SavedDataInTransaction<dynamic>(new { id = operation.compte, newAmount = newAmount }, query);

                    sql.ComitTransaction();
                }
                catch 
                {

                    sql.RollBackTransaction();
                }
            }

        }

        public void Update(Operation operation, decimal newAmount)
        {
            using (SqliteTransaction sql = new SqliteTransaction())
            {
                try
                {
                    sql.StartTransaction();
                    query = "update Operation set " +
                                        "date = @date , imputation = @imputation, " +
                                        "incrementer = @incrementer , decrementer = @decrementer, " +
                                        "beneficiaire = @beneficiaire , libelle = @libelle, " +
                                        "compte = @compte " +
                                        "where id = @id";
                    sql.SavedDataInTransaction<Operation>(operation, query);

                    query = "update Compte set montant = @newAmount where id = @id";

                    sql.SavedDataInTransaction<dynamic>(new { id = operation.compte, newAmount = newAmount }, query);

                    sql.ComitTransaction();
                }
                catch 
                {
                    
                    sql.RollBackTransaction();
                }
                
            }

            
        }

        public void Delete(IOperation operation,decimal newAmount)
        {
            using (SqliteTransaction sql = new SqliteTransaction())
            {
                try
                {
                    sql.StartTransaction();
                    query = "delete from Operation where id = @id";

                    sql.SavedDataInTransaction<dynamic>(new { id = operation.id }, query);

                    query = "update Compte set montant = @newAmount where id = @id";

                    sql.SavedDataInTransaction<dynamic>(new { id = operation.compte, newAmount = newAmount }, query);

                    sql.ComitTransaction();
                }
                catch 
                {

                    sql.RollBackTransaction();
                }

            }
            

        }
        public IOperation Get(int id)
        {
            query = "select * from Operation where id = @id";
            return _sqliteDataAccess.LoadData<Operation,dynamic>(query, new { id = id }).FirstOrDefault();
        }

    }
}
