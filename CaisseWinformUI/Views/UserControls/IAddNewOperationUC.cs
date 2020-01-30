using System;
namespace CaisseWinformUI.Views.UserControls
{
    public interface IAddNewOperationUC
    {
        event EventHandler SaveOperation;
        event EventHandler CancelNewOperation;
        string Date { get; set; }
        string Decrement { get; set; }
        string GetTextBeneficiaire { get; }
        string GetTextImputation { get; }
        int IdBeneficiaire { get; set; }
        int IdImputation { get; set; }
        string Increment { get; set; }
        string Libelle { get; set; }
        string Title { set; }
        System.Collections.Generic.IEnumerable<CaisseDTOsLibrary.Models.BeneficiaireModel.IBeneficiaire> SetBeneficiaireDataSource { set; }
        void SetErrorMessage(System.Collections.Generic.List<FluentValidation.Results.ValidationFailure> errors);
        System.Collections.Generic.IEnumerable<CaisseDTOsLibrary.Models.ImputationModel.IImputation> SetImputationDataSource { set; }
        void SetParent(System.Windows.Forms.Panel parentPanel);
        
    }
}
