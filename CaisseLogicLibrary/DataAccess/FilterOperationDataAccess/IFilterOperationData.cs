using System;
namespace CaisseLogicLibrary.DataAccess.FilterOperationDataAccess
{
    public interface IFilterOperationData
    {
        System.Collections.Generic.IEnumerable<CaisseDTOsLibrary.Models.FullOperationModel.IFullOperation> Filter(CaisseDTOsLibrary.Models.FilterOperationModel.IFilterOperation filterOperationModel);
    }
}
