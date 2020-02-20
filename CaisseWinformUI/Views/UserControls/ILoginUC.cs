using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface ILoginUC : IBaseUC
    {
        string GetUsername { get; }
        string GetPassword{ get; }
        string SetErrorMessage { set; }
        event EventHandler Login;
        event EventHandler SignUp;
        void ResetUC();
        string Version { set; }
    }
}
