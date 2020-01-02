using System;
namespace CaisseLogicLibrary.DataAccess.BeneficiaireData
{
     public interface IBeneficiaireDataAccess
     {
          void Delete(int id);
          CaisseDTOsLibrary.Models.BeneficiaireModel.Beneficiaire Get(int id);
          System.Collections.Generic.List<CaisseDTOsLibrary.Models.BeneficiaireModel.Beneficiaire> GetAll();
          void Insert(CaisseDTOsLibrary.Models.BeneficiaireModel.Beneficiaire beneficiaire);
          void Update(int id);
     }
}
