using System;
namespace CaisseLogicLibrary.DataAccess.ImputationDataAccess
{
    public interface IImputationData
    {
        void Delete(CaisseDTOsLibrary.Models.ImputationModel.IImputation imputation);
        CaisseDTOsLibrary.Models.ImputationModel.IImputation Get(int id, int compte);
        System.Collections.Generic.IEnumerable<CaisseDTOsLibrary.Models.ImputationModel.IImputation> GetAll(int compte);
        void Insert(CaisseDTOsLibrary.Models.ImputationModel.IImputation imputation);
        void Update(CaisseDTOsLibrary.Models.ImputationModel.IImputation imputation);
        int Search(string libelle, int compte);
    }
}
