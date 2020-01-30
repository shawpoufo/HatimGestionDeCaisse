using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface IOperationsUC:IBaseUC
    {
        System.Windows.Forms.Panel GetBottomPanel { get; }
        event EventHandler InitializeUCsValues;
        System.Windows.Forms.Panel GetMiddlePanel { get; }
        System.Windows.Forms.Panel GetTopPanel { get; }
    }
}
