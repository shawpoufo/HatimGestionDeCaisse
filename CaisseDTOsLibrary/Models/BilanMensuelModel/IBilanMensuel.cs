using System;
using CaisseDTOsLibrary.Models.CompteModel;
namespace CaisseDTOsLibrary.Models.BilanMensuelModel
{
     public interface IBilanMensuel
     {
          Compte compte { get; set; }
          DateTime date { get; set; }
          int id { get; set; }
          double montant { get; set; }
     }
}
