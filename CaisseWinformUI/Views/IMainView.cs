using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Views
{
    public interface IMainView
    {
        Panel GetHeaderPanel { get; }
        Panel GetBodyPanel { get; }
        event EventHandler MainViewClosed;
    }
}
