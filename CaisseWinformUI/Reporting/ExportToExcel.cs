using CaisseDTOsLibrary.Models.FullOperationModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Reporting
{
    public class ExportToExcel : CaisseWinformUI.Reporting.IExportToExcel
    {
        public ExportToExcel()
        {
                
        }

        public void Export(IEnumerable<IFullOperation> records,string fileName,string path)
        {
            FileInfo file = new FileInfo(Path.Combine(path, fileName + ".xlsx"));
            if (file.Exists)
                file.Delete();
            using(ExcelPackage ex = new ExcelPackage())
            {
                ExcelWorksheet newSheet = ex.Workbook.Worksheets.Add("Operations");
                newSheet.Cells[1, 1].LoadFromCollection(records,true,OfficeOpenXml.Table.TableStyles.Medium20);
                newSheet.Column(2).Style.Numberformat.Format = "dd/MM/yyyy";
                newSheet.DeleteColumn(1);
                newSheet.Cells[1, 1].Value = "Date";
                newSheet.Cells[1, 2].Value = "Imputation";
                newSheet.Cells[1, 3].Value = "Crédit";
                newSheet.Cells[1, 4].Value = "Débit";
                newSheet.Cells[1, 5].Value = "Bénéficiaire";
                newSheet.Cells[1, 6].Value = "Libellé";
                ChangeStyle(newSheet, records.ToList().Count + 1, 6);
                AutofitColumns(newSheet, 6);
                string fullPath = Path.Combine(path, fileName + ".xlsx");
                ex.SaveAs(new FileInfo(fullPath));
            }
        }

        private void AutofitColumns(ExcelWorksheet workSheet,int columnCount)
        {
            for (int i = 1; i <= columnCount; i++)
            {
                workSheet.Column(i).AutoFit();
            }
            
        }
        private void ChangeStyle(ExcelWorksheet workSheet,int endRow,int endCol)
        {
            workSheet.Cells[1, 1, endRow, endCol].Style.Font.SetFromFont(new Font("Calibri", 12));
        }
    }
}
