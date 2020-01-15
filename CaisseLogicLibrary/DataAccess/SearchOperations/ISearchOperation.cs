using System;
namespace CaisseLogicLibrary.DataAccess.SearchOperations
{
    public interface ISearchOperation
    {
        CaisseDTOsLibrary.Models.FullOperationModel.FullOperation Get(int id);
        System.Collections.Generic.List<CaisseDTOsLibrary.Models.FullOperationModel.FullOperation> GetAll();
    }
}
