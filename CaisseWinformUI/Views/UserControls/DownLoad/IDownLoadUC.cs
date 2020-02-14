using PopupControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Views.UserControls.DownLoad
{
    public interface IDownLoadUC
    {
        event EventHandler DownLoad;
        bool FileNameRequired { set; }
        bool Loading { set; }
        string FileName { set; }
    }
}
