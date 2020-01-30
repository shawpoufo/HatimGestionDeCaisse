using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface IMoveOperationsUC:IBaseUC
    {
        bool ButtonsMoveVisibility { set; }
        event EventHandler ChangeMonthValue;
        event EventHandler ChangeYearValue;
        string Month { get; set; }
        string Year { get; set; }
    }
}
