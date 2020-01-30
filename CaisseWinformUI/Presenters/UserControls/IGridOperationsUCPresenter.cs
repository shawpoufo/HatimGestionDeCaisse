using System;
using CaisseWinformUI.Views.UserControls;
using System.Collections.Generic;
using CaisseDTOsLibrary.Models.FullOperationModel;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface IGridOperationsUCPresenter
    {
        IGridOperationsUC GetUC { get;}
        IAddNewOperationUCPresenter GetNewOperationPresenter { get; }
        IFilterOperationsUCPresenter GetFilterOperationsUCPresenter { get; }
        void ProvideDgvDataSource(IEnumerable<IFullOperation> records);
        int IdCompte { get; set; }
        event EventHandler EndOfSaveOperation;
        event EventHandler ActivateFilter;
    }
}
