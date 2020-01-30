using System;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface IAddNewOperationUCPresenter
    {
        CaisseWinformUI.Views.UserControls.IAddNewOperationUC GetUC { get; }
        int IdAccount { get; set; }

        void ProvideImputationDataSource();
        void ProvideBeneficiareDataSource();
        event EventHandler CancelNewOperation;
        event EventHandler EndOfSaveOperation;
        int IdEditOperation { get; set; }
        void SetupOperationForEdit(int id);
        void ResetOperationForm();
    }
}
