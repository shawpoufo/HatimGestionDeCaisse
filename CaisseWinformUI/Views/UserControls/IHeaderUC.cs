using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Views.UserControls
{
    public interface IHeaderUC:IBaseUC
    {
        string Solde { get; set; }
        event EventHandler InitializeValues;
         event EventHandler ShowOperationsUC;
         event EventHandler ShowManageUC;
    }
}
