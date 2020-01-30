using CaisseDTOsLibrary.Models.OperationModel;
using System;
namespace CaisseLogicLibrary.DataAccess.OperationDataAccess
{
    public interface IOperationData
    {
        void Delete(int id);
        void Insert(CaisseDTOsLibrary.Models.OperationModel.Operation operation);
        void Update(CaisseDTOsLibrary.Models.OperationModel.Operation operation);
        IOperation Get(int id);
    }
}
