using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.BeneficiaireModel
{
     public class Beneficiaire : IBeneficiaire
     {
          public int id { get; set; }
          public string libelle { get; set; }
          public int compte { get; set; }
     }
}
