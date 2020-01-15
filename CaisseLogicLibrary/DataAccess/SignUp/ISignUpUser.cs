using System;
namespace CaisseLogicLibrary.DataAccess.SignUp
{
    public interface ISignUpUser
    {
        bool SignUp(CaisseDTOsLibrary.Models.LoginAccountModel.LoginAccount user);
    }
}
