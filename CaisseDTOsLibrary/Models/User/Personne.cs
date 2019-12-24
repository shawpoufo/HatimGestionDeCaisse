using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseDTOsLibrary.Models.User
{
     public class Personne : IPersonne
     {
          public int id { get; set; }
          public string username { get; set; }
          public string password { get; set; }
      
     }
}
