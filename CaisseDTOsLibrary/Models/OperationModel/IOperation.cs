using System;
namespace CaisseDTOsLibrary.Models.OperationModel
{
    public interface IOperation
    {
        int beneficiaire { get; set; }
        int compte { get; set; }
        string date { get; set; }
        double? decrementer { get; set; }
        int id { get; set; }
        int imputation { get; set; }
        double? incrementer { get; set; }
        string libelle { get; set; }
    }
}
