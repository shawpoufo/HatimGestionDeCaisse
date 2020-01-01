using System;
namespace CaisseDTOsLibrary.Models.LoginAccountModel
{
     public interface ILoginAccount
     {
          int id { get; set; }
          string password { get; set; }
          string username { get; set; }
     }
}
