using System;
namespace CaisseWinformUI.Models
{
    public interface IFullOperationModel
    {
        int rowNumber { get; set; }
        string beneficiaire { get; set; }
        DateTime date { get; set; }
        double decrementer { get; set; }
        int id { get; set; }
        string imputation { get; set; }
        double incrementer { get; set; }
        string libelle { get; set; }
        
    }
}
