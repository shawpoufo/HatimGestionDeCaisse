using System;
using CaisseDTOsLibrary.Models.LoginAccountModel;
namespace CaisseDTOsLibrary.Models.CompteModel
{
     public interface ICompte
     {
          int id { get; set; }
          LoginAccount loginAccount { get; set; }
          double montant { get; set; }
     }
}
