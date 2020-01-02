using System;
namespace CaisseLogicLibrary.DataAccess.ImutationDataAccess
{
     public interface IImutationData
     {
          void Delete(int id);
          CaisseDTOsLibrary.Models.ImutationModel.Imutation Get(int id);
          System.Collections.Generic.List<CaisseDTOsLibrary.Models.ImutationModel.Imutation> GetAll();
          void Insert(CaisseDTOsLibrary.Models.ImutationModel.Imutation imutation);
          void Update(int id);
     }
}
