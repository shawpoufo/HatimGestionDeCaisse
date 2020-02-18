using CaisseDTOsLibrary.Models.LoginAccountModel;
using System;
namespace CaisseWinformUI.Presenters
{
    public interface IMainViewPresenter
    {
        CaisseWinformUI.Views.IMainView GetView { get; }
        ILoginAccount _loginAccount { get; set; }
        void SendIdAccount();
    }
}
