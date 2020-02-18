using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseLogicLibrary.DataAccess.SearchOperations;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class OperationsUCPresenter : CaisseWinformUI.Presenters.UserControls.IOperationsUCPresenter
    {
        private IOperationsUC _operationsUC;
        public IOperationsUC GetUC { get { return _operationsUC;} }
        private IGridOperationsUCPresenter _gridOperationsUCPresenter;
        private ISearchOperationsUCPresenter _searchOperationsUCPresenter;
        private IMoveOperationsUCPresenter _moveOperationsUCPresenter;
        public event EventHandler RefreshAccount;
        public int IdCompte { get; set; }

        public OperationsUCPresenter(IOperationsUC operationsUC, IGridOperationsUCPresenter gridOperationsUCPresenter, ISearchOperationsUCPresenter searchOperationsUCPresenter, IMoveOperationsUCPresenter moveOperationsUCPresenter)
        {
            _operationsUC = operationsUC;
            _gridOperationsUCPresenter = gridOperationsUCPresenter;
            _searchOperationsUCPresenter = searchOperationsUCPresenter;
            _moveOperationsUCPresenter = moveOperationsUCPresenter;
            SubscribeToEventsSetup();
            SetUserControlsToPanel();
           
     
        }
        private void SubscribeToEventsSetup()
        {
            _operationsUC.InitializeUCsValues += _operationsUC_InitializeUCsValues;

            _searchOperationsUCPresenter.ProvideDataSource += _searchOperationsUCPresenter_ProvideDataSource;
            _searchOperationsUCPresenter.ShowAddNewOperationUC += _searchOperationsUCPresenter_ShowAddNewOperationUC;
            _searchOperationsUCPresenter.ShowFilterOperationUC += _searchOperationsUCPresenter_ShowFilterOperationUC;
            _searchOperationsUCPresenter.ReFiltering += _searchOperationsUCPresenter_ReFiltering;
            _searchOperationsUCPresenter.FilterDeactivated += _searchOperationsUCPresenter_FilterDeactivated;
            _gridOperationsUCPresenter.EndOfSaveOperation += _gridOperationsUCPresenter_EndOfSaveOperation;
            _gridOperationsUCPresenter.ActivateFilter += _gridOperationsUCPresenter_ActivateFilter;
            _moveOperationsUCPresenter.ChangeMonth += _moveOperationsUCPresenter_ChangeMonth;
            _moveOperationsUCPresenter.ChangeYear += _moveOperationsUCPresenter_ChangeYear;
            _searchOperationsUCPresenter.GetdownLoadUCPresenter.GetUC.DownLoad += GetUC_DownLoad;
            
            
        }

        async void GetUC_DownLoad(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(sender.ToString()))
            {
                _searchOperationsUCPresenter.GetdownLoadUCPresenter.GetUC.Loading = true;
                _searchOperationsUCPresenter.GetdownLoadUCPresenter.GetUC.ErrorMessage = "";
                int year = int.Parse(_moveOperationsUCPresenter.GetUC.Year);
                int month = int.Parse(_moveOperationsUCPresenter.GetUC.Month);
                List<FullOperation> records = _searchOperationsUCPresenter.ListFullOperations.Where(o => o.date.Year == year && o.date.Month == month).Cast<FullOperation>().ToList();
                List<FullOperation> previousMonthRecords;
                if(_searchOperationsUCPresenter.FlagFilteringActivate)
                {

                    previousMonthRecords = _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetPreviousMonthOperations(month,year).Cast<FullOperation>().ToList();

                }
                else
                {
                    if(month == 1)
                    {
                        previousMonthRecords = _searchOperationsUCPresenter.GetExceptedMonthOperation().Cast<FullOperation>().ToList();
                    }
                    else
                    {
                        previousMonthRecords = _searchOperationsUCPresenter.ListFullOperations.Where(o => o.date.Year == year && o.date.Month == month - 1).Cast<FullOperation>().ToList();
                    }
                }
                var result =  await Task.Run(()=>_searchOperationsUCPresenter.GetdownLoadUCPresenter.DownLoad(records,previousMonthRecords, sender.ToString(), Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()));
                if(result)
                {
                    _searchOperationsUCPresenter.HideDownLoadUC();
                    _searchOperationsUCPresenter.GetdownLoadUCPresenter.ResetUC();
                }
                else
                {
                    _searchOperationsUCPresenter.GetdownLoadUCPresenter.GetUC.Loading = false;
                    _searchOperationsUCPresenter.GetdownLoadUCPresenter.GetUC.ErrorMessage = "Veuillez férmer le fichier";
                }
                
            }
            else
            {
                _searchOperationsUCPresenter.GetdownLoadUCPresenter.GetUC.FileNameRequired = true;
            }
            
        }

        void _searchOperationsUCPresenter_FilterDeactivated(object sender, EventArgs e)
        {
            if (!_searchOperationsUCPresenter.FlagFilteringActivate)
            {
                _moveOperationsUCPresenter.GetUC.ButtonsMoveYearVisibility = false;
                _moveOperationsUCPresenter.ListRestrictedMonths = new List<int>();
                _moveOperationsUCPresenter.ListYear = new List<int>();
                _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetUC.ClearForm(); 
            }
        }


        void _searchOperationsUCPresenter_ProvideDataSource(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.ProvideDgvDataSource((List<FullOperation>)sender);

            if (!_searchOperationsUCPresenter.FlagFilteringActivate)
            {
                _moveOperationsUCPresenter.GetUC.Month = _searchOperationsUCPresenter.LastSearchedMonth.ToString();
                _moveOperationsUCPresenter.GetUC.Year = _searchOperationsUCPresenter.LastSearchedYear.ToString();
            }
            _moveOperationsUCPresenter.GetUC.CountOperation =_searchOperationsUCPresenter.ListFullOperations.Count().ToString();
        }

        void _moveOperationsUCPresenter_ChangeYear(object sender, EventArgs e)
        {

            int year = (int)sender;
            int month = int.Parse(_moveOperationsUCPresenter.GetUC.Month);
            _searchOperationsUCPresenter.SearchInList(year, month, "");
        }

        void _moveOperationsUCPresenter_ChangeMonth(object sender, EventArgs e)
        {
            int year = _searchOperationsUCPresenter.LastSearchedYear;
            int month = (int)sender;
            string term = _searchOperationsUCPresenter.LastSearchedTerm;

            if (!_searchOperationsUCPresenter.FlagFilteringActivate)
             _searchOperationsUCPresenter.LastSearchedMonth = (int)sender;
            else
            {
                year = int.Parse(_moveOperationsUCPresenter.GetUC.Year);
                term = "";
            }
            
            _searchOperationsUCPresenter.SearchInList(year, month, term);
        }

        void _searchOperationsUCPresenter_ReFiltering(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.FilterOperations();
           
        }

        void _gridOperationsUCPresenter_ActivateFilter(object sender, EventArgs e)
        {           
            _searchOperationsUCPresenter.FlagFilteringActivate = true;
            _searchOperationsUCPresenter.GetUC.SetVisibilityLabelFilter = true;
            _searchOperationsUCPresenter.ListFullOperations = ((List<FullOperation>)sender);
            _moveOperationsUCPresenter.GetUC.Month = _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedMonths().First().ToString();
            _moveOperationsUCPresenter.GetUC.Year = _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedYears().First().ToString();
            _moveOperationsUCPresenter.ListRestrictedMonths = _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedMonths();
            _moveOperationsUCPresenter.ListYear = GetDifferenceBetweenTwoYears(_gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedYears());           
            _moveOperationsUCPresenter.GetUC.ButtonsMoveYearVisibility = (_gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedYears().Distinct().ToList().Count > 1) ? true : false;
            _moveOperationsUCPresenter.GetUC.CountOperation = _searchOperationsUCPresenter.ListFullOperations.Count().ToString();
        }

        void _searchOperationsUCPresenter_ShowFilterOperationUC(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.GetUC.GetAsidePanel.Visible = true;
            ((UserControl)_gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetUC).BringToFront();
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.ProvideBeneficiareDataSource();
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.ProvideImputationDataSource();
           
        }

        void _gridOperationsUCPresenter_EndOfSaveOperation(object sender, EventArgs e)
        {
            int year = _searchOperationsUCPresenter.LastSearchedYear;
            int month = int.Parse(_moveOperationsUCPresenter.GetUC.Month);
            string term =_searchOperationsUCPresenter.LastSearchedTerm;
            _searchOperationsUCPresenter.StandardSearch(year, month, term);

            if (_searchOperationsUCPresenter.FlagFilteringActivate)
            {
                year = int.Parse(_moveOperationsUCPresenter.GetUC.Year);
                term = "";
            }
                
            _searchOperationsUCPresenter.Refresh(year,month, term);

            if (_searchOperationsUCPresenter.FlagFilteringActivate)
            {
                _moveOperationsUCPresenter.GetUC.Month = month.ToString();
                _moveOperationsUCPresenter.GetUC.Year = year.ToString();
            }
            _gridOperationsUCPresenter.GetUC.GetAsidePanel.Visible = false;

            if (RefreshAccount != null)
                RefreshAccount(this, EventArgs.Empty);

        }

        void _operationsUC_InitializeUCsValues(object sender, EventArgs e)
        {
            _searchOperationsUCPresenter.IdAccountLoggin = IdCompte;
            _gridOperationsUCPresenter.IdCompte = IdCompte;
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.idCompte = IdCompte;
            _gridOperationsUCPresenter.GetNewOperationPresenter.IdAccount = IdCompte;
            _searchOperationsUCPresenter.SearchInDataBase(DateTime.Now.Year, DateTime.Now.Month, "");
            _gridOperationsUCPresenter.GetNewOperationPresenter.ProvideBeneficiareDataSource();
            _gridOperationsUCPresenter.GetNewOperationPresenter.ProvideImputationDataSource();   
        }

        void _searchOperationsUCPresenter_ShowAddNewOperationUC(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.GetUC.GetAsidePanel.Visible = true;
            ((UserControl)_gridOperationsUCPresenter.GetNewOperationPresenter.GetUC).BringToFront();
            _gridOperationsUCPresenter.GetNewOperationPresenter.GetUC.Title = "Ajouter";
            _gridOperationsUCPresenter.GetNewOperationPresenter.ResetOperationForm();
            
        }


        private void SetUserControlsToPanel()
        {           
            _searchOperationsUCPresenter.GetUC.SetParent(_operationsUC.GetTopPanel);
            _gridOperationsUCPresenter.GetUC.SetParent(_operationsUC.GetMiddlePanel);
            _moveOperationsUCPresenter.GetUC.SetParent(_operationsUC.GetBottomPanel);        
        }
        private List<int> GetDifferenceBetweenTwoYears(List<int> listYears)
        {
            List<int> years = new List<int>();
            for (int i = listYears[0]; i <= listYears[1]; i++)
            {
                years.Add(i);
            }
            return years;
        }
    }
}
