using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface ISearchOperationsUC:IBaseUC
    {
        event EventHandler NewOperation;
        event EventHandler Filter;
        event EventHandler QuickSearch;
        event EventHandler Refresh;
        event EventHandler ShowDownLoadUC;
        int GetYear { get; }
        string GetTerm { get; }
        bool SetVisibilityLabelFilter { set; }

    }
}
