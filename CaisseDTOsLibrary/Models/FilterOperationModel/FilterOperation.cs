using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.ImputationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.FilterOperationModel
{
    public class FilterOperation : CaisseDTOsLibrary.Models.FilterOperationModel.IFilterOperation 
    {
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public List<int> listImputation { get; set; }
        public List<int> listBeneficiare { get; set; }
        public List<string> listLibelle { get; set; }
        public int compte { get; set; }
    }
}
