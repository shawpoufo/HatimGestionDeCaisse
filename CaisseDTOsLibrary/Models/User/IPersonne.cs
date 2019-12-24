using System;
namespace CaisseDTOsLibrary.Models.User
{
     public interface IPersonne
     {
          int id { get; set; }
          string password { get; set; }
          string username { get; set; }
     }
}
