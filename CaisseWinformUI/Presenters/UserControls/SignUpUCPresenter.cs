using AutoMapper;
using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseLogicLibrary.DataAccess.Login;
using CaisseWinformUI.Models;
using CaisseWinformUI.Validators;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class SignUpUCPresenter : ISignUpUCPresenter
    {
        private ISignUpUC _signUpUC;
        private ILogger _logger;
        private ILoginAccount _loginAccount;
        private IMapper _mapper;
        private LoginAccountValidator validator;

        public event EventHandler ShowLoginUCView;

        public SignUpUCPresenter(ISignUpUC signUpUC, ILogger logger, ILoginAccount loginAccount, IMapper mapper)
        {
            _signUpUC = signUpUC;
            _logger = logger;
            _loginAccount = loginAccount;
            _mapper = mapper;
            validator = new LoginAccountValidator();
            InitializeSignUpUCEvents();
        }
        private void InitializeSignUpUCEvents()
        {
            _signUpUC.SignUp += _signUpUC_SignUp;
            _signUpUC.Login += _signUpUC_Login;
        }

        void _signUpUC_Login(object sender, EventArgs e)
        {
            if (ShowLoginUCView != null)
                ShowLoginUCView(this, EventArgs.Empty);
        }

        void _signUpUC_SignUp(object sender, EventArgs e)
        {
            LoginAccountModel account = InitializeLoginAccountModel();
        }

        public SignUpUC GetUserControl()
        {
            return (SignUpUC)_signUpUC;
        }

        private LoginAccountModel InitializeLoginAccountModel()
        {
            return new LoginAccountModel()
            {
                username = _signUpUC.GetUsername,
                password = _signUpUC.GetPassword
            };
        }

    }
}
