using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;

namespace CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess
{
     public class BeneficiaireData : CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess.IBeneficiaireData 
     {
          private ISqliteDataAccess _sqliteDataAccess;
          private string query { get; set; }

          public BeneficiaireData(ISqliteDataAccess sqliteDataAccess)
          {
               _sqliteDataAccess = sqliteDataAccess;
          }
          public void Insert(IBeneficiaire beneficiaire)
          {

              query = "insert into Beneficiaire (libelle,compte) values (@libelle,@compte)";
              _sqliteDataAccess.SaveData<Beneficiaire>(query, (Beneficiaire)beneficiaire);
          }

          public void Update(IBeneficiaire beneficiaire)
          {
               query = "update Beneficiaire set libelle = @libelle where id = @id and compte =@compte";
               _sqliteDataAccess.SaveData<Beneficiaire>(query, (Beneficiaire)beneficiaire);
          }

          public void Delete(int id,int compte)
          {
              query = "delete from Beneficiaire where id = @id and compte = @compte";
              _sqliteDataAccess.SaveData<dynamic>(query, new { id = id, compte = compte });
          }

          public IBeneficiaire Get(int id, int compte)
          {
              query = "select * from Beneficiaire where id = @id and compte = @compte";
              var beneficiaire = _sqliteDataAccess.LoadData<Beneficiaire, dynamic>(query, new { id = id, compte = compte }).FirstOrDefault();
               return beneficiaire;
          }

          public IEnumerable<IBeneficiaire> GetAll(int compte)
          {
               query = "select * from Beneficiaire where compte = @compte";
               var beneficiaires = _sqliteDataAccess.LoadData<Beneficiaire, dynamic>(query, new { compte = compte });
               return beneficiaires;
          }
          public int Search(string libelle, int compte)
          {
              query = "select id from Beneficiaire where libelle LIKE @libelle and compte = @compte";
              var idBeneficiaire = _sqliteDataAccess.LoadData<int, dynamic>(query, new { libelle = libelle, compte = compte }).FirstOrDefault();
              return idBeneficiaire;
          }
     }
}
