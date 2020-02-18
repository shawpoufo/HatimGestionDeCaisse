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

        public IFullOperation Get(int id)
        {
            query = @"select o.id,o.date, " +
                    "i.libelle as imputation, " +
                    "o.incrementer,o.decrementer, " +
                    "b.libelle as beneficiaire, " +
                    "o.libelle " +
                    "from Operation o " +
                    "LEFT JOIN Imputation i ON i.id = o.imputation " +
                    "LEFT JOIN Beneficiaire b ON b.id = o.beneficiaire " +
                    "LEFT JOIN Compte c ON c.id = o.compte " +
                    "where o.compte = @id ";
            var fullOperation = _sqliteDataAccess.LoadData<FullOperation, dynamic>(query, new { id = id }).FirstOrDefault();

            return fullOperation;
        }

        public IEnumerable<IFullOperation> GetAll(int id)
        {
            query = "select o.id,o.date,'' as splitImputation " +
                    "i.id,i.libelle,'' as splitBeneficier " +
                    "b.id,b.libelle,'' as splitCompte " +
                    "c.id,c.montant " +
                    "from Operation o " +
                    "LEFT JOIN Imputation i ON i.id = o.imputation " +
                    "LEFT JOIN Beneficiaire b ON b.id = o.beneficiaire " +
                    "LEFT JOIN Compte c ON c.id = o.compte "+
                    "where o.compte = @id ";
                    
            var ListFullOperation = _sqliteDataAccess.LoadData<FullOperation, dynamic>(query, new {id=id });

            return ListFullOperation;
        }

        public IEnumerable<IFullOperation> QuickSearch(int year, string term, int id)
        {
            query = @"select o.id,o.date, " +
                    "i.libelle as imputation, " +
                    "o.incrementer,o.decrementer, " +
                    "b.libelle as beneficiaire, " +
                    "o.libelle " +
                    "from Operation o " +
                    "LEFT JOIN Imputation i ON i.id = o.imputation " +
                    "LEFT JOIN Beneficiaire b ON b.id = o.beneficiaire " +
                    "LEFT JOIN Compte c ON c.id = o.compte " +
                    "where o.compte = @id " +
                    "and strftime('%Y',o.date) = @year ";

            if (!string.IsNullOrEmpty(term))
                query += @"and (i.libelle LIKE @term OR b.libelle LIKE @term OR o.libelle LIKE @term ) ";

            query += @"ORDER by o.date ASC ";



            var ListFullOperation = _sqliteDataAccess.LoadData<FullOperation, dynamic>(query, new { id = id, year = year.ToString(), term = "%"+term+"%" });

            return ListFullOperation;
        }
        
    }
}
