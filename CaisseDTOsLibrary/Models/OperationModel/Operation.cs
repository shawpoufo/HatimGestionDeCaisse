using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.CompteModel;

namespace CaisseDTOsLibrary.Models.OperationModel
{
     public class Operation : IOperation
     {
          public int id { get; set; }
          public DateTime date { get; set; }
          public Imputation imputation { get; set; }
          public Double? incrementer { get; set; }
          public Double? decrementer { get; set; }
          public Beneficiaire beneficiaire { get; set; }
          public string libelle { get; set; }

          
     }
}
