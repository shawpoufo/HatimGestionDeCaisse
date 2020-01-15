using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.SearchOperations
{
    public class SearchOperation : ISearchOperation
    {
        private ISqliteDataAccess _sqliteDataAccess;
        private string query { get; set; }

        public SearchOperation(ISqliteDataAccess sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess;
        }

        public FullOperation Get(int id)
        {
            query = "select o.id,o.date,'' as splitImputation " +
                    "i.id,i.libelle,'' as splitBeneficier "+
                    "b.id,b.libelle,'' as splitCompte "+
                    "c.id,c.montant "+
                    "from Operation o , Imputation i , Beneficiaire b , Compte c " +
                    "where id = @id";
            var fullOperation = _sqliteDataAccess.LoadData<FullOperation, dynamic>(query, new { id = id }).FirstOrDefault();
            return fullOperation;
        }

        public List<FullOperation> GetAll()
        {
            query = "select o.id,o.date,'' as splitImputation " +
                    "i.id,i.libelle,'' as splitBeneficier " +
                    "b.id,b.libelle,'' as splitCompte " +
                    "c.id,c.montant " +
                    "from Operation o , Imputation i , Beneficiaire b , Compte c ";
                    
            var ListFullOperation = _sqliteDataAccess.LoadData<FullOperation, dynamic>(query, new { });
            return ListFullOperation;
        }
    }
}
