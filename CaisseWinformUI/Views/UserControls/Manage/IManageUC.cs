using System;
namespace CaisseWinformUI.Views.UserControls.Manage
{
    public interface IManageUC:IBaseUC
    {
        int GetIdUpdateBeneficiary { get; }
        int GetIdUpdateImputation { get; }
        string LibelleBeneficiary { get; set; }
        string LibelleImputation { get; set; }
        string SetErrorMessageBeneficiaryLibelle { set; }
        string SetErrorMessageBeneficiaryList { set; }
        string SetErrorMessageImputationLibelle { set; }
        string SetErrorMessageImputationList { set; }
        object SetDataSourceImputation { set; }
        object SetDataSourceBeneficiary { set; }
        event EventHandler UpdateBeneficiary;
        event EventHandler UpdateImputation;
    }
}
