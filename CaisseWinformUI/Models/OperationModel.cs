using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Models
{
    public class OperationModel : CaisseWinformUI.Models.IOperationModel
    {
        public int id { get; set; }
        public string date { get; set; }
        public int? imputation { get; set; }
        public double? incrementer { get; set; }
        public double? decrementer { get; set; }
        public int? beneficiaire { get; set; }
        public string libelle { get; set; }
        public int compte { get; set; }
    }
}
