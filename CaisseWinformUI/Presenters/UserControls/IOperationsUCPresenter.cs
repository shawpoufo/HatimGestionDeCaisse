using CaisseWinformUI.Views.UserControls;
using System;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface IOperationsUCPresenter
    {
        int IdCompte { get; set; }
        IOperationsUC GetUC { get; }
    }
}
