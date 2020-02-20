using System;
namespace CaisseWinformUI.Presenters.UserControls.Update
{
    public interface IUpdateUCPresenter
    {
        CaisseWinformUI.Views.UserControls.UpdateScreen.IUpdateUC GetUC { get; }
        System.Threading.Tasks.Task UpdateApp();
    }
}
