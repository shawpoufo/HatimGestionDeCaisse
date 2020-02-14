using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Views.UserControls
{
    public interface IGridOperationsUC:IBaseUC
    {
        DataGridView GetDGV { get; }
        Panel GetAsidePanel { get; }
        string TotalGeneral { get;set;}
        string Decrement { get; set; }
        string Increment { get; set; }
        event EventHandler ShowEditOperation;
        event EventHandler ShowMessageDeleteOpeartion;
    }
}
