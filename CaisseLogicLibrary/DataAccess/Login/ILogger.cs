using System;
namespace CaisseLogicLibrary.DataAccess.Login
{
    public interface ILogger
    {
        int Login(CaisseDTOsLibrary.Models.LoginAccountModel.ILoginAccount user);
    }
}
