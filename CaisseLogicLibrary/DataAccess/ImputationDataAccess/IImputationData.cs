using CaisseDTOsLibrary.Models.ImputationModel;
using System;
using System.Collections.Generic;
namespace CaisseLogicLibrary.DataAccess.ImputationDataAccess
{
     public interface IImputationData
     {
          void Delete(int id);
          Imputation Get(int id);
          List<CaisseDTOsLibrary.Models.ImputationModel.Imputation> GetAll();
          void Insert(Imputation imutation);
          void Update(Imputation imputation);
     }
}
