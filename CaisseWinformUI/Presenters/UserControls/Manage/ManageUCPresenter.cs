using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess;
using CaisseLogicLibrary.DataAccess.ImputationDataAccess;
using CaisseWinformUI.Views.UserControls.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls.Manage
{
    public class ManageUCPresenter : CaisseWinformUI.Presenters.UserControls.Manage.IManageUCPresenter
    {
        private IManageUC _manageUC;
        public IManageUC GetUC { get { return _manageUC; } }
        private IBeneficiaireData _beneficiaireData;
        private IImputationData _imputationData;
        public int IdAccount { get; set; }

        public ManageUCPresenter(IManageUC manageUC, IBeneficiaireData beneficiaireData, IImputationData imputationData)
        {
            _manageUC = manageUC;
            _beneficiaireData = beneficiaireData;
            _imputationData = imputationData;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _manageUC.UpdateBeneficiary += _manageUC_UpdateBeneficiary;
            _manageUC.UpdateImputation += _manageUC_UpdateImputation;
        }

        void _manageUC_UpdateImputation(object sender, EventArgs e)
        {
            if(_manageUC.GetIdUpdateImputation > 0)
            {
                if (!string.IsNullOrEmpty(_manageUC.LibelleImputation))
                {
                    _imputationData.Update(new Imputation() { id = _manageUC.GetIdUpdateImputation, libelle = _manageUC.LibelleImputation, compte = IdAccount });
                    ResetUC();
                }
                else
                {
                    _manageUC.SetErrorMessageImputationLibelle = "* Champ obligatoire";
                }
                
            }
            else
            {

                _manageUC.SetErrorMessageImputationList = "Veuillez choisire une imputation depuis la liste";
            }
        }

        void _manageUC_UpdateBeneficiary(object sender, EventArgs e)
        {
            if (_manageUC.GetIdUpdateBeneficiary != 0 )
            {
                if (!string.IsNullOrEmpty(_manageUC.LibelleBeneficiary))
                {
                    _beneficiaireData.Update(new Beneficiaire() { id = _manageUC.GetIdUpdateBeneficiary, libelle = _manageUC.LibelleBeneficiary, compte = IdAccount });
                    ResetUC();
                }
                else
                {
                    _manageUC.SetErrorMessageBeneficiaryLibelle = "* Champ obligatoire";
                }
                
            }
            else
            {
                _manageUC.SetErrorMessageBeneficiaryList = "Veuillez choisire un bénéficiare depuis la liste";
            }
        }

        private void RefreshImputaionsValues()
        {           
            List<Imputation> imputations = _imputationData.GetAll(IdAccount).Cast<Imputation>().ToList();
            imputations.Insert(0, new Imputation() { id = 0, libelle = "-- Veuillez choisire --" });
            _manageUC.SetDataSourceImputation = imputations;
        }
        private void RefreshBeneficiaryValues()
        {
            List<Beneficiaire> beneficiaires = _beneficiaireData.GetAll(IdAccount).Cast<Beneficiaire>().ToList();
            beneficiaires.Insert(0, new Beneficiaire() { id = 0, libelle = "-- Veuillez choisire --" });
            _manageUC.SetDataSourceBeneficiary = beneficiaires;
        }
        public void ResetUC()
        {
            RefreshImputaionsValues();
            RefreshBeneficiaryValues();
            _manageUC.LibelleBeneficiary = "";
            _manageUC.LibelleImputation = "";
            _manageUC.SetErrorMessageBeneficiaryLibelle = "";
            _manageUC.SetErrorMessageBeneficiaryList = "";
            _manageUC.SetErrorMessageImputationLibelle = "";
            _manageUC.SetErrorMessageImputationList = "";
            
        }

    }
}
