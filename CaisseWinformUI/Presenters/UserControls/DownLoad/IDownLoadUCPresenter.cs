using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseWinformUI.Views.UserControls.DownLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls.DownLoad
{
    public interface IDownLoadUCPresenter
    {
        IDownLoadUC GetUC { get; }
        bool DownLoad(IEnumerable<IFullOperation> records, IEnumerable<IFullOperation> previousMonthRecords, string fileName, string path);
        void ResetUC();
    }
}
