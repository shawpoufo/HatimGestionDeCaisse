﻿using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.FilterOperationModel;
using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess;
using CaisseLogicLibrary.DataAccess.FilterOperationDataAccess;
using CaisseLogicLibrary.DataAccess.ImputationDataAccess;
using CaisseWinformUI.Validators;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class FilterOperationsUCPresenter : CaisseWinformUI.Presenters.UserControls.IFilterOperationsUCPresenter
    {
        private IFilterOperationsUC _filterOperationsUC;
        public IFilterOperationsUC GetUC { get { return _filterOperationsUC; } }
        private IImputationData _imputationData;
        private IBeneficiaireData _beneficiaireData;
        private IFilterOperation _filterOperationModel;
        private IFilterOperationData _filterOperationData;
        public int idCompte {get;set;}
        public event EventHandler EndOfFiltering;
        public event EventHandler CloseFilterForm;
        private FilterOperationValidator _filterOperationValidator;

        public FilterOperationsUCPresenter(IFilterOperationsUC filterOperationsUC, IImputationData imputationData, IBeneficiaireData beneficiaireData, IFilterOperation filterOperationModel, IFilterOperationData filterOperationData)
        {
            _filterOperationsUC = filterOperationsUC;
            _imputationData = imputationData;
            _beneficiaireData = beneficiaireData;
            _filterOperationModel = filterOperationModel;
            _filterOperationData = filterOperationData;
            _filterOperationValidator = new FilterOperationValidator(); 
            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _filterOperationsUC.Filter += _filterOperationsUC_Filter;
            _filterOperationsUC.AddSelectedImputation += _filterOperationsUC_AddSelectedImputation;
            _filterOperationsUC.RemoveSelectedImputation += _filterOperationsUC_RemoveSelectedImputation;
            _filterOperationsUC.AddSelectedBeneficiary += _filterOperationsUC_AddSelectedBeneficiary;
            _filterOperationsUC.RemoveSelectedBeneficiary += _filterOperationsUC_RemoveSelectedBeneficiary;
            _filterOperationsUC.CancelFilterOperation += _filterOperationsUC_CancelFilterOperation;
        }

        void _filterOperationsUC_CancelFilterOperation(object sender, EventArgs e)
        {
            if (CloseFilterForm != null)
                CloseFilterForm(this, EventArgs.Empty);
        }

        void _filterOperationsUC_RemoveSelectedBeneficiary(object sender, EventArgs e)
        {
            RemoveObjectFromComboBox(_filterOperationsUC.GetCbxSelectedBeneficiarys, _filterOperationsUC.LabelErrorBeneficiary);
            _filterOperationsUC.CountBeneficiary = _filterOperationsUC.GetCbxSelectedBeneficiarys.Items.Count.ToString();
        }

        void _filterOperationsUC_AddSelectedBeneficiary(object sender, EventArgs e)
        {
            AddObjectToComboBox(_filterOperationsUC.GetCbxBeneficiarys, _filterOperationsUC.GetCbxSelectedBeneficiarys, _filterOperationsUC.LabelErrorBeneficiary);
            _filterOperationsUC.CountBeneficiary = _filterOperationsUC.GetCbxSelectedBeneficiarys.Items.Count.ToString();
        }

        void _filterOperationsUC_RemoveSelectedImputation(object sender, EventArgs e)
        {
            RemoveObjectFromComboBox(_filterOperationsUC.GetCbxSelectedImputations, _filterOperationsUC.LabelErrorImputation);
            _filterOperationsUC.CountImputions = _filterOperationsUC.GetCbxSelectedImputations.Items.Count.ToString();
        }

        void _filterOperationsUC_AddSelectedImputation(object sender, EventArgs e)
        {
            AddObjectToComboBox(_filterOperationsUC.GetCbxImputations, _filterOperationsUC.GetCbxSelectedImputations, _filterOperationsUC.LabelErrorImputation);
            _filterOperationsUC.CountImputions = _filterOperationsUC.GetCbxSelectedImputations.Items.Count.ToString();
        }

        void _filterOperationsUC_Filter(object sender, EventArgs e)
        {
            FilterOperations();
        }
        public void ProvideImputationDataSource()
        {

            _filterOperationsUC.GetCbxImputations.DataSource = _imputationData.GetAll(idCompte).Cast<Imputation>().ToList();

            _filterOperationsUC.GetCbxImputations.SelectedIndex = -1;

        }
        public void ProvideBeneficiareDataSource()
        {
            _filterOperationsUC.GetCbxBeneficiarys.DataSource = _beneficiaireData.GetAll(idCompte).Cast<Beneficiaire>().ToList();

            _filterOperationsUC.GetCbxBeneficiarys.SelectedIndex = -1;
        }
        public void FilterOperations()
        {
            List<string> datesToValidate = new List<string>() { _filterOperationsUC.GetDateFrom, _filterOperationsUC.GetDateTo };
            if (_filterOperationValidator.ValidateRegexDate(datesToValidate))
            {
                if (_filterOperationValidator.ValidateDate(datesToValidate))
                {
                    if (_filterOperationValidator.DateToShouldBeHigher(datesToValidate))
                    {
                        _filterOperationModel = InitializeFilterOperationModel();
                        var ls = _filterOperationData.Filter(_filterOperationModel);
                        _filterOperationsUC.SetErrorDateMessage = "";
                        if (EndOfFiltering != null)
                            EndOfFiltering(ls, EventArgs.Empty); 
                    }
                    else
                        _filterOperationsUC.SetErrorDateMessage = "La date 'Au' doit être supérieur a la date 'Du'";
                }
                else
                    _filterOperationsUC.SetErrorDateMessage = "Date invalide";

            }
            else
            {
                _filterOperationsUC.SetErrorDateMessage = string.Format("Veuillez respecter l'un de c'est format : \n{0}  ;  {1}  ;  {2}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("MM/yyyy"), DateTime.Now.Year);
            }
        }

        private FilterOperation InitializeFilterOperationModel()
        {
            return new FilterOperation()
            {
                dateFrom = _filterOperationsUC.GetDateFrom,
                dateTo = _filterOperationsUC.GetDateTo,
                listImputation = (_filterOperationsUC.GetCbxSelectedImputations.Items.Count > 0) ? (_filterOperationsUC.GetCbxSelectedImputations.Items.Cast<Imputation>()).Select(i => i.id).ToList() : new List<int>(),
                listBeneficiare = (_filterOperationsUC.GetCbxSelectedBeneficiarys.Items.Count > 0) ? (_filterOperationsUC.GetCbxSelectedBeneficiarys.Items.Cast<Beneficiaire>()).Select(i => i.id).ToList() : new List<int>(),
                listLibelle = _filterOperationsUC.Libelles.Split(';').Where(l => !string.IsNullOrEmpty(l.Trim())).ToList(),
                compte = idCompte
            };
        }
        private void AddObjectToComboBox(ComboBox comboBoxFrom,ComboBox comboBoxTo,Label labelErrorMessage)
        {
            var selectedItem = comboBoxFrom.SelectedItem;
            var selectedValue = Convert.ToInt32(comboBoxFrom.SelectedValue);
            string className = (comboBoxFrom.Name.ToLower().Contains("imputation")) ? "Imputations" : "Bénéficiaires";
            if (selectedItem != null && selectedValue > 0)
            {
                if (!comboBoxTo.Items.Contains(selectedItem))
                {
                    comboBoxTo.Items.Add(selectedItem);
                    comboBoxTo.SelectedItem = selectedItem;
                    labelErrorMessage.Text = "";
                }
                else
                {
                    
                    string str = (selectedItem is Imputation)? "choisie":"choisi";
                    labelErrorMessage.Text = string.Format("Cette élément existe déjà dans \nla List des {0} {1}", className, str);
                }
            }
            else
            {
                labelErrorMessage.Text = string.Format("Veuillez choisir un élément qui se trouve dans \nla List des {0}", className);
            }
        }
        private void RemoveObjectFromComboBox(ComboBox comboBoxFrom,Label labelErrorMessage)
        {
            if (comboBoxFrom.Items.Count > 0)
            {
                var selectedItem = comboBoxFrom.SelectedItem;

                if (selectedItem != null)
                {
                    if (comboBoxFrom.Items.Contains(selectedItem))
                    {
                        comboBoxFrom.Items.Remove(selectedItem);
                        if (comboBoxFrom.Items.Count > 0)
                        {
                            comboBoxFrom.SelectedIndex = 0;
                            labelErrorMessage.Text = "";
                        }
                        else
                        {
                            comboBoxFrom.Text = "";
                            labelErrorMessage.Text = "";
                        }
                    }
                }
                else
                {
                    string className = (selectedItem is Imputation) ? "Imputations" : "Bénéficiaires";
                    string str = (selectedItem is Imputation) ? "choisie" : "choisi";
                    labelErrorMessage.Text = "Veuillez choisir un élément qui se trouve \ndans la list choisie";
                }
            }
            else
            {
                string className = (labelErrorMessage.Name.ToLower().Contains("imputation")) ? "Imputations" : "Bénéficiaires";
                string str = (labelErrorMessage.Name.ToLower().Contains("imputation")) ? "choisie" : "choisi";
                labelErrorMessage.Text = string.Format("Vous ne pouvez pas supprimer car \nLa List des {0} {1} est vide",className,str);
            }
        }
        public List<int> GetRistrectedYears()
        {
            List<int> restrictedYears = new List<int>();
            restrictedYears.Add(Convert.ToInt32(_filterOperationModel.dateFrom.Substring(_filterOperationModel.dateFrom.Length - 4, 4)));
            restrictedYears.Add(Convert.ToInt32(_filterOperationModel.dateTo.Substring(_filterOperationModel.dateTo.Length - 4, 4)));
            return restrictedYears;
        }
        public List<int> GetRistrectedMonths()
        {
            List<int> restrictedMonths = new List<int>();
            Regex regex = new Regex(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$");
            if (regex.Match(_filterOperationModel.dateFrom).Success)
            {
                restrictedMonths.Add(Convert.ToInt32(_filterOperationModel.dateFrom.Substring(3, 2)));
                restrictedMonths.Add(Convert.ToInt32(_filterOperationModel.dateTo.Substring(3, 2))); 
            }
            regex = new Regex(@"^((((0)[1-9])|((1)[0-2]))(\/)\d{4})$");
            if (regex.Match(_filterOperationModel.dateFrom).Success)
            {
                restrictedMonths.Add(Convert.ToInt32(_filterOperationModel.dateFrom.Substring(0, 2)));
                restrictedMonths.Add(Convert.ToInt32(_filterOperationModel.dateTo.Substring(0, 2)));
            }
            regex = new Regex(@"^(\d{1,4})$");
            if (regex.Match(_filterOperationModel.dateFrom).Success)
            {
                restrictedMonths.Add(1);
                restrictedMonths.Add(12);
            }
            return restrictedMonths;
        }
        public IEnumerable<IFullOperation> GetPreviousMonthOperations(int currentMonth,int currentYear)
        {
            int previousMonth = (currentMonth == 1) ? 12 : currentMonth - 1;
            int previousYear = (currentMonth == 1) ? currentYear - 1 : currentYear;
            FilterOperation newModel = new FilterOperation();
            newModel.dateFrom = (new DateTime(previousYear,previousMonth,01)).ToString("dd/MM/yyyy");
            newModel.dateTo = (new DateTime(previousYear, previousMonth,DateTime.DaysInMonth(previousYear,previousMonth))).ToString("dd/MM/yyyy");
            newModel.listImputation = _filterOperationModel.listImputation;
            newModel.listBeneficiare = _filterOperationModel.listBeneficiare;
            newModel.listLibelle = _filterOperationModel.listLibelle;
            newModel.compte = _filterOperationModel.compte;

            return _filterOperationData.Filter(newModel);
        }
        
    }
}
