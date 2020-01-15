using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseSqlLogicLibrary.SqliteDataAccess;

using CaisseDTOsLibrary.Models.ImputationModel;

namespace CaisseLogicLibrary.DataAccess.ImputationDataAccess
{
     public class ImputationData : IImputationData
     {
          private ISqliteDataAccess _sqliteDataAccess;
          private string query { get; set; }
          public ImputationData(ISqliteDataAccess sqliteDataAccess)
          {
               _sqliteDataAccess = sqliteDataAccess;
               
          }

          public void Insert(Imputation imputation)
          {

              query = "insert into Imputation (libelle) values (@libelle)";
               _sqliteDataAccess.SaveData<Imputation>(query, imputation);
          }

          public void Update(Imputation imputation)
          {
              query = "update Imputation set libelle = @libelle where id = @id";
              _sqliteDataAccess.SaveData<Imputation>(query,imputation);
          }

          public void Delete(int id)
          {
              query = "delete from Imputation where id = @id";
               _sqliteDataAccess.SaveData<dynamic>(query, new { id = id });
          }

          public Imputation Get(int id)
          {
              query = "select * from Imputation where id = @id";
               var imutation = _sqliteDataAccess.LoadData<Imputation, dynamic>(query, new { id = id }).FirstOrDefault();
               return imutation;
          }

          public List<Imputation> GetAll()
          {
              query = "select * from Imputation ";
               var imutation = _sqliteDataAccess.LoadData<Imputation, dynamic>(query, new { });
               return imutation;
          }
     }
}
