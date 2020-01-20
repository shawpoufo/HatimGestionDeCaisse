using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CaisseWinformUI.Models;

namespace CaisseWinformUI.Validators
{
    public class SignUpValidator : AbstractValidator<LoginAccountModel>
    {
        public SignUpValidator()
        {
            RuleFor(s => s.username)
                .NotEmpty();

            RuleFor(s => s.password)
                .NotEmpty(); 

            RuleFor(s => s.email)
                .NotEmpty();
        }
    }
}
