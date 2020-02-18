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

        public bool Export(IEnumerable<IFullOperation> records,IEnumerable<IFullOperation> previousMonthRecords,string fileName,string path)
        {
            try
            {
                
                FileInfo file = new FileInfo(Path.Combine(path, fileName + ".xlsx"));
                if (file.Exists)
                    file.Delete();
                using (ExcelPackage ex = new ExcelPackage())
                {
                    ExcelWorksheet newSheet = ex.Workbook.Worksheets.Add("Operations");
                    newSheet.Cells[1, 1].LoadFromCollection(records, true, OfficeOpenXml.Table.TableStyles.Medium20);
                    newSheet.Column(2).Style.Numberformat.Format = "dd/MM/yyyy";
                    newSheet.DeleteColumn(1);
                    newSheet.Cells[1, 1].Value = "Date";
                    newSheet.Cells[1, 2].Value = "Imputation";
                    newSheet.Cells[1, 3].Value = "Crédit";
                    newSheet.Cells[1, 4].Value = "Débit";
                    newSheet.Cells[1, 5].Value = "Bénéficiaire";
                    newSheet.Cells[1, 6].Value = "Libellé";
                    ChangeStyle(newSheet, records.ToList().Count + 1, 6);
                    //-- Bottom Line --//
                    int indexLastRow = records.ToList().Count + 1;
                    decimal credit = SumOfCredit(records.Cast<FullOperation>().ToList());
                    decimal debit = SumOfDebit(records.Cast<FullOperation>().ToList());
                    indexLastRow++;
                    newSheet.Cells[indexLastRow, 1].Value = "Total";
                    newSheet.Cells[indexLastRow, 3].Value = credit;
                    newSheet.Cells[indexLastRow, 4].Value = debit;
                    indexLastRow++;
                    newSheet.Cells[indexLastRow, 1].Value = "Solde";
                    newSheet.Cells[indexLastRow, 3].Value = Total(credit, debit);
                    indexLastRow++;
                    newSheet.Cells[indexLastRow, 1].Value = "Ancien solde";
                    newSheet.Cells[indexLastRow, 3].Value = Total(SumOfCredit(previousMonthRecords.Cast<FullOperation>().ToList()), SumOfDebit(previousMonthRecords.Cast<FullOperation>().ToList()));

                    //----------------//
                    AutofitColumns(newSheet, 6);
                    string fullPath = Path.Combine(path, fileName + ".xlsx");
                    ex.SaveAs(new FileInfo(fullPath));
                }
            }
            catch 
            {

                return false;
            }
            return true;
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

        private decimal SumOfCredit(List<FullOperation> records)
        {
            decimal total = 0;
            foreach(var item in records)
            {
                total = decimal.Add(total, Convert.ToDecimal(item.incrementer)); 
            }

            return total;
        }
        private decimal SumOfDebit(List<FullOperation> records)
        {
            decimal total = 0;
            foreach (var item in records)
            {
                total = decimal.Add(total, Convert.ToDecimal(item.decrementer));
            }

            return total;
        }
        private decimal Total(decimal credit , decimal debit)
        {
            return decimal.Subtract(credit,debit);
        }
    }
}
