using System;
using CaisseDTOsLibrary.Models.FullOperationModel;
using System.Collections.Generic;
namespace CaisseLogicLibrary.DataAccess.SearchOperations
{
    public interface ISearchOperation
    {
        CaisseDTOsLibrary.Models.FullOperationModel.IFullOperation Get(int id);
        IEnumerable<IFullOperation> GetAll(int id);
        IEnumerable<IFullOperation> QuickSearch(int year, string term, int id);
    }
}
