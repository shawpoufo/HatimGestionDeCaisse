using CaisseWinformUI.Views.UserControls;
using System;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface ILoginUCPresenter
    {
        LoginUC GetUserControl();
        event EventHandler ShowMainView;
        event EventHandler ShowSignUpUC;
        void ResetUC();
    }
}
