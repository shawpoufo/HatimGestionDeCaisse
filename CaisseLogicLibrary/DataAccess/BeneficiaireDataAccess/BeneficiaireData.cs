﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;

namespace CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess
{
     public class BeneficiaireData : IBeneficiaireData
     {
          private ISqliteDataAccess _sqliteDataAccess;
          private string query { get; set; }

          public BeneficiaireData(ISqliteDataAccess sqliteDataAccess)
          {
               _sqliteDataAccess = sqliteDataAccess;
          }
          public void Insert(Beneficiaire beneficiaire)
          {

               query = "insert into Beneficiaire (libelle) values (@libelle)";
               _sqliteDataAccess.SaveData<Beneficiaire>(query, beneficiaire);
          }

          public void Update(Beneficiaire beneficiaire)
          {
               query = "update Beneficiaire set libelle = @libelle where id = @id";
               _sqliteDataAccess.SaveData<Beneficiaire>(query, beneficiaire);
          }

          public void Delete(int id)
          {
               query = "delete from Beneficiaire where id = @id";
               _sqliteDataAccess.SaveData<dynamic>(query, new { id = id });
          }

          public Beneficiaire Get(int id)
          {
               query = "select * from Beneficiaire where id = @id";
               var beneficiaire = _sqliteDataAccess.LoadData<Beneficiaire, dynamic>(query, new { id = id }).FirstOrDefault();
               return beneficiaire;
          }

          public List<Beneficiaire> GetAll()
          {
               query = "select * from Beneficiaire ";
               var beneficiaire = _sqliteDataAccess.LoadData<Beneficiaire, dynamic>(query, new { });
               return beneficiaire;
          }
     }
}