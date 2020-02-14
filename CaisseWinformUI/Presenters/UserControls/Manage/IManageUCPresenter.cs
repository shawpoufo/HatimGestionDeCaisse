using System;
namespace CaisseWinformUI.Presenters.UserControls.Manage
{
    public interface IManageUCPresenter
    {
        CaisseWinformUI.Views.UserControls.Manage.IManageUC GetUC { get; }
        int IdAccount { get; set; }
        void ResetUC();
    }
}
