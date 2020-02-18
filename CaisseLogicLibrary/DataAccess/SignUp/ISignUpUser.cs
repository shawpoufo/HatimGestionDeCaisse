using System;
namespace CaisseLogicLibrary.DataAccess.SignUp
{
    public interface ISignUpUser
    {
        bool SignUp(CaisseDTOsLibrary.Models.LoginAccountModel.ILoginAccount user);
        bool UsernameExists(string username);
        bool EmailExists(string email);
    }
}
