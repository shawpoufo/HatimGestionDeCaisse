using AutoMapper;
using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseLogicLibrary.DataAccess.SignUp;
using CaisseWinformUI.Models;
using CaisseWinformUI.Validators;
using CaisseWinformUI.Views.UserControls;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class SignUpUCPresenter : ISignUpUCPresenter
    {
        private ISignUpUC _signUpUC;
        private ISignUpUser _signUpUser;
        private ILoginAccount _loginAccount;
        private IMapper _mapper;
        private SignUpValidator validator;

        public event EventHandler ShowLoginUCView;

        public SignUpUCPresenter(ISignUpUC signUpUC, ISignUpUser signUpUser, ILoginAccount loginAccount, IMapper mapper)
        {
            _signUpUC = signUpUC;
            _signUpUser = signUpUser;
            _loginAccount = loginAccount;
            _mapper = mapper;
            validator = new SignUpValidator((SignUpUser)_signUpUser);
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
            ValidationResult results = validator.Validate(account);

            if(results.IsValid)
            {
                _loginAccount = _mapper.Map<LoginAccount>(account);

                bool check = _signUpUser.SignUp(_loginAccount);
                if (check)
                {
                    _signUpUC.SetErrorMessage = "Vous êtes inscrit avec succès veuillez vous diriger \nvers la page de connexion.";
                    _signUpUC.SetColorErrorMessage = Color.Green;
                }
                else
                {
                    _signUpUC.SetErrorMessage = "Une erreur vient de se produire veuillez répéter,\nsinon veuillez contacter votre administrateur. ";
                    _signUpUC.SetColorErrorMessage = Color.Red;
                }
            }
            else
            {
                List<ValidationFailure> failures = results.Errors.ToList();
                if (failures.Count > 0)
                    _signUpUC.SetErrorMessage = failures.FirstOrDefault().ErrorMessage;
            }
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
                password = _signUpUC.GetPassword,
                email = _signUpUC.GetEmail
            };
        }

    }
}
