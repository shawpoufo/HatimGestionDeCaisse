using System;
namespace CaisseLogicLibrary.DataAccess.ImputationDataAccess
{
     public interface IImputationData
     {
          void Delete(int id);
          CaisseDTOsLibrary.Models.ImputationModel.Imputation Get(int id);
          System.Collections.Generic.List<CaisseDTOsLibrary.Models.ImputationModel.Imputation> GetAll();
          void Insert(CaisseDTOsLibrary.Models.ImputationModel.Imputation imutation);
          void Update(int id);
     }
}
