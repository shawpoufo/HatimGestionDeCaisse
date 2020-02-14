using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface IMoveOperationsUC:IBaseUC
    {
        bool ButtonsMoveYearVisibility { set; }
        event EventHandler ChangeMonthValue;
        event EventHandler ChangeYearValue;
        string Month { get; set; }
        string Year { get; set; }
        string CountOperation { get; set; }
    }
}
