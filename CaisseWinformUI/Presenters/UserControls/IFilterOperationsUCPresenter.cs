using System;
using System.Collections.Generic;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface IFilterOperationsUCPresenter
    {
        CaisseWinformUI.Views.UserControls.IFilterOperationsUC GetUC { get; }
        int idCompte { get; set; }
        void ProvideBeneficiareDataSource();
        void ProvideImputationDataSource();
        event EventHandler EndOfFiltering;
        event EventHandler CloseFilterForm;
        void FilterOperations();
        List<int> GetRistrectedYears();
        List<int> GetRistrectedMonths();
    }
}
