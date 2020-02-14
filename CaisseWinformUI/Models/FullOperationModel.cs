using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Models
{
    public class FullOperationModel : CaisseWinformUI.Models.IFullOperationModel
    {
        public int rowNumber { get; set; }
        public int id { get; set; }
        public DateTime date { get; set; }
        public string imputation { get; set; }
        public double incrementer { get; set; }
        public double decrementer { get; set; }
        public string beneficiaire { get; set; }
        public string libelle { get; set; }
    }
}
