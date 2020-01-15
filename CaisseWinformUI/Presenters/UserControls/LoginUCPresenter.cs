using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseWinformUI.Views.UserControls;
using CaisseLogicLibrary.DataAccess.Login;
using CaisseDTOsLibrary.Models.LoginAccountModel;
using AutoMapper;
using CaisseWinformUI.Models;
using CaisseWinformUI.Validators;
using FluentValidation.Results;
namespace CaisseWinformUI.Presenters.UserControls
{
    public class LoginUCPresenter : CaisseWinformUI.Presenters.UserControls.ILoginUCPresenter
    {
        private ILoginUC _loginUC;
        private ILogger _logger;
        private ILoginAccount _loginAccount;
        private IMapper _mapper;
        private LoginAccountValidator validator;

        public event EventHandler ShowMainView;
        public event EventHandler ShowSignUpUC;

        public LoginUCPresenter(ILoginUC loginUC, ILogger logger, ILoginAccount loginAccount ,IMapper mapper)
        {
            _loginUC = loginUC;
            _logger = logger;
            _loginAccount = loginAccount;
            _mapper = mapper;
            validator = new LoginAccountValidator();
            InitializeLoginUCEvents();
        }

        private void InitializeLoginUCEvents()
        {
            _loginUC.Login += _loginUC_Login;
            _loginUC.SignUp += _loginUC_SignUp;
            
        }

        void _loginUC_SignUp(object sender, EventArgs e)
        {
            if (ShowSignUpUC != null)
                ShowSignUpUC(this,EventArgs.Empty);
        }

        void _loginUC_Login(object sender, EventArgs e)
        {
            LoginAccountModel account = InitializeLoginAccountModel();
            ValidationResult results = validator.Validate(account);

            if(results.IsValid)
            {
                _loginAccount = _mapper.Map<LoginAccount>(account);

                int check = _logger.Login(_loginAccount);

                if(check != 0)
                {
                    if (ShowMainView != null)
                        ShowMainView(_loginAccount,EventArgs.Empty);
                }
                else
                {
                    _loginUC.SetErrorMessage = "Username et/ou password incorrecte";
                }
            }
            else
            {
                List<ValidationFailure> failures = results.Errors.ToList();
                if (failures.Count > 0)
                    _loginUC.SetErrorMessage = failures.FirstOrDefault().ErrorMessage;
            }
            
        }
        public LoginUC GetUserControl()
        {
            return (LoginUC)_loginUC;
        }
        private LoginAccountModel InitializeLoginAccountModel()
        {
            return new LoginAccountModel()
            {
                username = _loginUC.GetUsername,
                password = _loginUC.GetPassword
            };
        }
    }
}
