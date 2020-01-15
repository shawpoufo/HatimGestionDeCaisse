using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CaisseWinformUI.Models;

namespace CaisseWinformUI.Validators
{
    public class LoginAccountValidator : AbstractValidator<LoginAccountModel>
    {
        public LoginAccountValidator()
        {
            RuleFor(l => l.username)
                .NotEmpty();

            RuleFor(l => l.password)
                .NotEmpty();
        }
    }
}
