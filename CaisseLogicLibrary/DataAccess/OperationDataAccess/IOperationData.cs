using CaisseDTOsLibrary.Models.OperationModel;
using System;
namespace CaisseLogicLibrary.DataAccess.OperationDataAccess
{
    public interface IOperationData
    {
        void Delete(IOperation operation, decimal newAmount);
        void Insert(CaisseDTOsLibrary.Models.OperationModel.Operation operation,decimal newAmount);
        void Update(Operation operation, decimal newAmount);
        IOperation Get(int id);
    }
}
