using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using CaisseDTOsLibrary.Models.ImutationModel;

namespace CaisseLogicLibrary.DataAccess.ImutationDataAccess
{
     public class ImutationData : IImutationData
     {
          private ISqliteDataAccess _sqliteDataAccess;
          private string query { get; set; }
          public ImutationData(ISqliteDataAccess sqliteDataAccess)
          {
               _sqliteDataAccess = sqliteDataAccess;
               
          }

          public void Insert(Imutation imutation)
          {

               query = "insert into Imutation (id,libelle) values (@id,@libelle)";
               _sqliteDataAccess.SaveData<Imutation>(query, imutation);
          }

          public void Update(int id)
          {
               query = "update Imutation set libelle = @libelle where id = @id";
               _sqliteDataAccess.SaveData<dynamic>(query, new { id = id });
          }

          public void Delete(int id)
          {
               query = "delete from Imutation where id = @id";
               _sqliteDataAccess.SaveData<dynamic>(query, new { id = id });
          }

          public Imutation Get(int id)
          {
               query = "select * from Imutation where id = @id";
               var imutation = _sqliteDataAccess.LoadData<Imutation,dynamic>(query, new { id = id }).FirstOrDefault();
               return imutation;
          }

          public List<Imutation> GetAll()
          {
               query = "select * from Imutation ";
               var imutation = _sqliteDataAccess.LoadData<Imutation, dynamic>(query, new { });
               return imutation;
          }
     }
}
