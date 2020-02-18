using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.SignUp
{
    public class SignUpUser : CaisseLogicLibrary.DataAccess.SignUp.ISignUpUser
    {
        private ISqliteDataAccess _sqlDataAccess;

        public SignUpUser(ISqliteDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public bool SignUp(ILoginAccount user)
        {
            return _sqlDataAccess.SignUpTransaction<LoginAccount>((LoginAccount)user);
        }
        public bool UsernameExists(string username)
        {
            return (_sqlDataAccess.LoadData<int, dynamic>("select EXISTS (select username from LoginAccount where username = @username)", new { username = username }).First() == 1);
        }
        public bool EmailExists(string email)
        {
            return (_sqlDataAccess.LoadData<int, dynamic>("select EXISTS (select email from LoginAccount where email = @email)", new { email = email }).First() == 1);
        }


    }
}
