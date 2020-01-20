using CaisseWinformUI.Views.UserControls;
using System;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface ISignUpUCPresenter
    {
        event EventHandler ShowLoginUCView;
        SignUpUC GetUserControl();
    }
}
