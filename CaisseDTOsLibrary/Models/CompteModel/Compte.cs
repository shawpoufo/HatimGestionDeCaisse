using CaisseDTOsLibrary.Models.LoginAccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.CompteModel
{
     public class Compte : ICompte
     {
          public int id { get; set; }
          public Double montant { get; set; }
          public LoginAccount loginAccount { get; set; }
     }
}
