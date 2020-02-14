using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.ImputationModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace CaisseWinformUI.Views.UserControls
{
    public interface IFilterOperationsUC : IBaseUC
    {
        ComboBox GetCbxImputations { get; }
        ComboBox GetCbxBeneficiarys { get; }
        ComboBox GetCbxSelectedImputations { get; }
        ComboBox GetCbxSelectedBeneficiarys { get; }
        string GetDateFrom { get; }
        string GetDateTo { get; }
        event EventHandler Filter;
        string Libelles { get; }
        string SetErrorDateMessage { set; }
        Label LabelErrorImputation { get; }
        Label LabelErrorBeneficiary { get; }
        event EventHandler AddSelectedImputation;
        event EventHandler RemoveSelectedImputation;
        event EventHandler AddSelectedBeneficiary;
        event EventHandler RemoveSelectedBeneficiary;
        event EventHandler CancelFilterOperation;
        void ClearForm();
        string CountImputions { set; }
        string CountBeneficiary { set; }

    }
}
