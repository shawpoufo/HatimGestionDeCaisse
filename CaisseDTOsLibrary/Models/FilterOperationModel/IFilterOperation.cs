using System;
namespace CaisseDTOsLibrary.Models.FilterOperationModel
{
    public interface IFilterOperation
    {
        int compte { get; set; }
        string dateFrom { get; set; }
        string dateTo { get; set; }
        System.Collections.Generic.List<int> listBeneficiare { get; set; }
        System.Collections.Generic.List<int> listImputation { get; set; }
        System.Collections.Generic.List<string> listLibelle { get; set; }
    }
}
