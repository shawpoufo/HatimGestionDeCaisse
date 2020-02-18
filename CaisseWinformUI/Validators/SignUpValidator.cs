using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CaisseWinformUI.Models;
using CaisseLogicLibrary.DataAccess.SignUp;

namespace CaisseWinformUI.Validators
{
    public class SignUpValidator : AbstractValidator<LoginAccountModel>
    {
        private SignUpUser _signUpUser;
        public SignUpValidator(SignUpUser signUpUser)
        {
            _signUpUser = signUpUser;
            RuleFor(s => s.username)
                .NotEmpty()
                .MinimumLength(6)
                .Must(BeUniqueUsername).WithMessage("Ce 'username' existé déjà veuillez le changer.");

            RuleFor(s => s.password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
                .WithMessage(" 'password' doit contenir au moins 1 lettre majuscule, 1 lettre minuscule et 1 chiffre");             

            RuleFor(s => s.email)
                .NotEmpty()
                .EmailAddress()
                .Must(BeUniqueEmail).WithMessage("Cet 'email' existé déjà veuillez le changer."); ;
        }

        private bool BeUniqueUsername(string username)
        {
           return !_signUpUser.UsernameExists(username);
        }
        private bool BeUniqueEmail(string email)
        {
            return !_signUpUser.EmailExists(email);
        }
    }
}
