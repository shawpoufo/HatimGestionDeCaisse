using CaisseDTOsLibrary.Models.CompteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.BilanMensuelModel
{
     public class BilanMensuel : IBilanMensuel
     {
          public int id { get; set; }
          public DateTime date { get; set; }
          public Double montant { get; set; }
          public Compte compte { get; set; }
     }
}
