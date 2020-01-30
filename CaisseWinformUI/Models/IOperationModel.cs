using System;
namespace CaisseWinformUI.Models
{
    public interface IOperationModel
    {
         int id { get; set; }
         string date { get; set; }
         int? imputation { get; set; }
         double? incrementer { get; set; }
         double? decrementer { get; set; }
         int? beneficiaire { get; set; }
         string libelle { get; set; }
         int compte { get; set; }
    }
}
