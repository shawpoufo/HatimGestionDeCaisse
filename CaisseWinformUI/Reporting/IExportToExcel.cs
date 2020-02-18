using CaisseDTOsLibrary.Models.FullOperationModel;
using System;
using System.Collections.Generic;
namespace CaisseWinformUI.Reporting
{
    public interface IExportToExcel
    {
        bool Export(IEnumerable<IFullOperation> records, IEnumerable<IFullOperation> previousMonthRecords, string fileName, string path);
    }
}
