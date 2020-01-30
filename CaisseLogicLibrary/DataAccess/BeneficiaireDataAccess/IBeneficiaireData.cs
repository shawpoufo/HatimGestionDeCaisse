using System;
namespace CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess
{
    public interface IBeneficiaireData
    {
        void Delete(int id, int compte);
        CaisseDTOsLibrary.Models.BeneficiaireModel.IBeneficiaire Get(int id, int compte);
        System.Collections.Generic.IEnumerable<CaisseDTOsLibrary.Models.BeneficiaireModel.IBeneficiaire> GetAll(int compte);
        void Insert(CaisseDTOsLibrary.Models.BeneficiaireModel.IBeneficiaire beneficiaire);
        void Update(CaisseDTOsLibrary.Models.BeneficiaireModel.IBeneficiaire beneficiaire);
        int Search(string libelle, int compte);
    }
}
