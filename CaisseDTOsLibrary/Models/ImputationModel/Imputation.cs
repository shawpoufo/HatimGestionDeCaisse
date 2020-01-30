using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.ImputationModel
{
     public class Imputation : IImputation
     {
          public int id { get; set; }
          public string libelle { get; set; }
          public int compte { get; set; }
     }
}
