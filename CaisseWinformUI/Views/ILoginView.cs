using System;
namespace CaisseWinformUI.Views
{
    public interface ILoginView
    {
        System.Windows.Forms.Panel GetParentPanel();
        event EventHandler ShowLoginUC;
    }
}
