using System;
using CaisseWinformUI.Views.UserControls;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface IHeaderUCPresenter
    {
        IHeaderUC GetUC { get; }
        int IdAccount { get; set; }
        void RefreshAccountAmount();
    }
}
