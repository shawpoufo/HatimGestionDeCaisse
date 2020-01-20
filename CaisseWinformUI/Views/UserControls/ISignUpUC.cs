using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface ISignUpUC:IBaseUC
    {
        string GetEmail { get; }
        string GetPassword { get; }
        string GetUsername { get; }
        event EventHandler Login;
        string SetErrorMessage { set; }
        event EventHandler SignUp;
    }
}
