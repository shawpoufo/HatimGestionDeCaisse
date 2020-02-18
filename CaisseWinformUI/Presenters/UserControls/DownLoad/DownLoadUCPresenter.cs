using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseWinformUI.Reporting;
using CaisseWinformUI.Views.UserControls.DownLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls.DownLoad
{
    public class DownLoadUCPresenter : IDownLoadUCPresenter
    {
        private IDownLoadUC _downLoadUC;
        private IExportToExcel _exportToExcel;
        public IDownLoadUC GetUC { get { return _downLoadUC; } }
        

        public DownLoadUCPresenter(IDownLoadUC downLoadUC, IExportToExcel exportToExcel)
        {
            _downLoadUC = downLoadUC;
            _exportToExcel = exportToExcel;
        }

        public bool DownLoad(IEnumerable<IFullOperation> records, IEnumerable<IFullOperation> previousMonthRecords, string fileName, string path)
        {
            
            return  _exportToExcel.Export(records,previousMonthRecords, fileName, path);

        }
        public void ResetUC()
        {
            _downLoadUC.FileNameRequired = false;
            _downLoadUC.Loading = false;
            _downLoadUC.FileName = "";
        }

        
    }
}
