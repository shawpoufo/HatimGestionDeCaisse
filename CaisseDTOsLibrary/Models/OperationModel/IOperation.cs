using System;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.ImputationModel;
namespace CaisseDTOsLibrary.Models.OperationModel
{
     public interface IOperation
     {
          Beneficiaire beneficiaire { get; set; }
          DateTime date { get; set; }
          double? decrementer { get; set; }
          int id { get; set; }
          Imputation imputation { get; set; }
          double? incrementer { get; set; }
          string libelle { get; set; }
     }
}
