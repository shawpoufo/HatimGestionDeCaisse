using System;
using System.Collections.Generic;
namespace CaisseWinformUI.Presenters.UserControls
{
    public interface IMoveOperationsUCPresenter
    {
        event EventHandler ChangeMonth;
        event EventHandler ChangeYear;
        CaisseWinformUI.Views.UserControls.IMoveOperationsUC GetUC { get; }
        List<int> ListYear { get; set; }
        List<int> ListRestrictedMonths { get; set; }
    }
}
