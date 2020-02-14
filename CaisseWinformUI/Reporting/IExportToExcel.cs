using System;
namespace CaisseWinformUI.Reporting
{
    public interface IExportToExcel
    {
        void Export(System.Collections.Generic.IEnumerable<CaisseDTOsLibrary.Models.FullOperationModel.IFullOperation> records, string fileName, string path);
    }
}
