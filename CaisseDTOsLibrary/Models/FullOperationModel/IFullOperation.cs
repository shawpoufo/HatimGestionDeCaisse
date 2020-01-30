using System;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseDTOsLibrary.Models.CompteModel;
namespace CaisseDTOsLibrary.Models.FullOperationModel
{
    public interface IFullOperation
    {
        int id { get; set; }
        DateTime date { get; set; }
        string imputation { get; set; }
        double incrementer { get; set; }
        double decrementer { get; set; }
        string beneficiaire { get; set; }
        string libelle { get; set; }
    }
}
