using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CaisseWinformUI.Models;
using System.Globalization;
namespace CaisseWinformUI.Validators
{
    class OperationValidator : AbstractValidator<OperationModel>
    {
        public OperationValidator()
        {
            RuleFor(o => o.date)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .Matches(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$").WithMessage("Le format de la date est incorrecte ex :" + DateTime.Now.ToString("dd/MM/yyyy"))
                    .Must(BeAValidDate).WithMessage("La date est invalide");

            RuleFor(o => o.imputation)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEqual(0).WithMessage("Veuillez choisir une imputation,\n ou écrire une nouvelle");

            RuleFor(o => o.beneficiaire)
                    .NotEqual(0).WithMessage("Veuillez choisir un bénéficiaire,\n ou écrire un nouveau");

            RuleFor(o => o.libelle)
                    .NotEmpty();

        }
        private bool BeAValidDate(string date)
        {
            DateTime fromDateValue;

            return DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue);
        }
        public bool BeOneOrLessNull(double? valueOne, double? valueTwo)
        {
            return (valueOne != null || valueTwo != null);
        }
    }
}
