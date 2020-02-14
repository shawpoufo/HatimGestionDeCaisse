using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseDTOsLibrary.Models.FilterOperationModel;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess;
using CaisseLogicLibrary.DataAccess.FilterOperationDataAccess;
using CaisseLogicLibrary.DataAccess.ImputationDataAccess;
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
        public FilterOperationsUCPresenter(IFilterOperationsUC filterOperationsUC, IImputationData imputationData, IBeneficiaireData beneficiaireData, IFilterOperation filterOperationModel, IFilterOperationData filterOperationData)
        {
            _filterOperationsUC = filterOperationsUC;
            _imputationData = imputationData;
            _beneficiaireData = beneficiaireData;
            _filterOperationModel = filterOperationModel;
            _filterOperationData = filterOperationData;
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

            List<Imputation> imputations = _imputationData.GetAll(idCompte).Cast<Imputation>().ToList();
            imputations.Insert(0, new Imputation() { id = 0, libelle = "Veuillez choisire ..." });
            _filterOperationsUC.GetCbxImputations.DataSource = imputations;

        }
        public void ProvideBeneficiareDataSource()
        {
            List<Beneficiaire> beneficiaires = _beneficiaireData.GetAll(idCompte).Cast<Beneficiaire>().ToList();
            beneficiaires.Insert(0, new Beneficiaire() { id = 0, libelle = "Veuillez choisire ..." });
            _filterOperationsUC.GetCbxBeneficiarys.DataSource = beneficiaires;
        }
        public void FilterOperations()
        {
            List<string> datesToValidate = new List<string>() { _filterOperationsUC.GetDateFrom, _filterOperationsUC.GetDateTo };
            if (ValidateRegexDate(datesToValidate))
            {
                if (ValidateDate(datesToValidate))
                {
                    if (DateToShouldBeHigher(datesToValidate))
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
        private bool ValidateRegexDate(List<string> datesToValidate)
        {
            Regex regex = new Regex(@"^(([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4})$|^((((0)[1-9])|((1)[0-2]))(\/)\d{4})$|^(\d{1,4})$");
            var success1 = regex.Match(datesToValidate[0]).Success;
            var success2 = regex.Match(datesToValidate[1]).Success;
            return (success1 && success2 && (datesToValidate[0].Length == datesToValidate[1].Length));
        }
        private bool ValidateDate(List<string> datesToValidate)
        {
            Regex regex = new Regex(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$");
            if(regex.Match(datesToValidate[0]).Success)
            {
                DateTime fromDateValue1;
                DateTime fromDateValue2;
                var succes1 = DateTime.TryParseExact(datesToValidate[0], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue1);
                var succes2 = DateTime.TryParseExact(datesToValidate[1], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue2);

                return (succes1 && succes2);
            }

            return true;
        }
        private bool DateToShouldBeHigher(List<string> datesToValidate)
        {
            Regex regex = new Regex(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$");
            if(regex.Match(datesToValidate.First()).Success)
            {
                string[] from = datesToValidate.First().Split('/');
                string[] to = datesToValidate.Last().Split('/');
                DateTime dateFrom = new DateTime(Convert.ToInt32(from[2]), Convert.ToInt32(from[1]), Convert.ToInt32(from[0]));
                DateTime dateTo = new DateTime(Convert.ToInt32(to[2]), Convert.ToInt32(to[1]), Convert.ToInt32(to[0]));

                if (DateTime.Compare(dateTo, dateFrom) >= 0)
                    return true;
            }

            regex = new Regex(@"^((((0)[1-9])|((1)[0-2]))(\/)\d{4})$");

            if (regex.Match(datesToValidate.First()).Success)
            {
                string[] from = datesToValidate.First().Split('/');
                string[] to = datesToValidate.Last().Split('/');
                DateTime dateFrom = new DateTime(Convert.ToInt32(from[1]),Convert.ToInt32(from[0]),01);
                DateTime dateTo = new DateTime( Convert.ToInt32(to[1]), Convert.ToInt32(to[0]),12);

                if (DateTime.Compare(dateTo, dateFrom) >= 0)
                    return true;
            }

            regex = new Regex(@"^(\d{1,4})$");
            if (regex.Match(datesToValidate.First()).Success)
            {
                if (Convert.ToInt32(datesToValidate.Last()) >= Convert.ToInt32(datesToValidate.First()))
                    return true;
            }


            return false;
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
            var selectedIndex = comboBoxFrom.SelectedIndex;
            string className = (selectedItem is Imputation) ? "Imputations" : "Bénéficiaires";
            if (selectedItem != null && selectedIndex > 0)
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
        
    }
}
