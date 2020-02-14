using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseSqlLogicLibrary.SqliteDataAccess;

using CaisseDTOsLibrary.Models.ImputationModel;

namespace CaisseLogicLibrary.DataAccess.ImputationDataAccess
{
    public class ImputationData : CaisseLogicLibrary.DataAccess.ImputationDataAccess.IImputationData
    {
        private ISqliteDataAccess _sqliteDataAccess;
        private string query { get; set; }
        public ImputationData(ISqliteDataAccess sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess;

        }

        public void Insert(IImputation imputation)
        {

            query = "insert into Imputation (libelle,compte) values (@libelle,@compte)";
            _sqliteDataAccess.SaveData<Imputation>(query, (Imputation)imputation);
        }

        public void Update(IImputation imputation)
        {
            query = "update Imputation set libelle = @libelle where id = @id and compte = @compte";
            _sqliteDataAccess.SaveData<Imputation>(query, (Imputation)imputation);
        }

        public void Delete(IImputation imputation)
        {
            query = "delete from Imputation where id = @id and compte = @compte";
            _sqliteDataAccess.SaveData<Imputation>(query, (Imputation)imputation);
        }

        public IImputation Get(int id, int compte)
        {
            query = "select * from Imputation where id = @id and compte = @compte";
            var imutation = _sqliteDataAccess.LoadData<Imputation, dynamic>(query, new { id = id, compte = compte }).FirstOrDefault();
            return imutation;
        }

        public IEnumerable<IImputation> GetAll(int compte)
        {
            query = "select * from Imputation where compte = @compte";
            var imutation = _sqliteDataAccess.LoadData<Imputation, dynamic>(query, new { compte = compte });
            return imutation;
        }
        public int Search(string libelle, int compte)
        {
            query = "select id from Imputation where libelle LIKE @libelle and compte = @compte";
            var idImputation = _sqliteDataAccess.LoadData<int, dynamic>(query, new { libelle = libelle, compte = compte }).FirstOrDefault();
            return idImputation;
        }
    }
}
