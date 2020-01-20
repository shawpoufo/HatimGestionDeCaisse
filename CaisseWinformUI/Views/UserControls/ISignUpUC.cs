using System;
using System.Drawing;
namespace CaisseWinformUI.Views.UserControls
{
    public interface ISignUpUC:IBaseUC
    {
        string GetEmail { get; }
        string GetPassword { get; }
        string GetUsername { get; }
        event EventHandler Login;
        string SetErrorMessage { set; }
        Color SetColorErrorMessage { set;}
        event EventHandler SignUp;
    }
}
