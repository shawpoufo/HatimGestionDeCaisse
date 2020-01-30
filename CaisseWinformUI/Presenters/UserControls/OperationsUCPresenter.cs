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
        private ISearchOperation _searchOperation;
        private IGridOperationsUCPresenter _gridOperationsUCPresenter;
        private ISearchOperationsUCPresenter _searchOperationsUCPresenter;
        private IMoveOperationsUCPresenter _moveOperationsUCPresenter;

        public int IdCompte { get; set; }

        public OperationsUCPresenter(IOperationsUC operationsUC, ISearchOperation searchOperation, IGridOperationsUCPresenter gridOperationsUCPresenter, ISearchOperationsUCPresenter searchOperationsUCPresenter, IMoveOperationsUCPresenter moveOperationsUCPresenter)
        {
            _operationsUC = operationsUC;
            _searchOperation = searchOperation;
            _gridOperationsUCPresenter = gridOperationsUCPresenter;
            _searchOperationsUCPresenter = searchOperationsUCPresenter;
            _moveOperationsUCPresenter = moveOperationsUCPresenter;
            SubscribeToEventsSetup();
            SetUserControlsToPanel();
     
        }
        private void SubscribeToEventsSetup()
        {
            _operationsUC.InitializeUCsValues += _operationsUC_InitializeUCsValues;

            _searchOperationsUCPresenter.QuickSearchEnd += _searchOperationsUCPresenter_QuickSearchEnd;
            _searchOperationsUCPresenter.ShowAddNewOperationUC += _searchOperationsUCPresenter_ShowAddNewOperationUC;
            _searchOperationsUCPresenter.ShowFilterOperationUC += _searchOperationsUCPresenter_ShowFilterOperationUC;
            _searchOperationsUCPresenter.ReFiltering += _searchOperationsUCPresenter_ReFiltering;
            _gridOperationsUCPresenter.EndOfSaveOperation += _gridOperationsUCPresenter_EndOfSaveOperation;
            _gridOperationsUCPresenter.ActivateFilter += _gridOperationsUCPresenter_ActivateFilter;
            _moveOperationsUCPresenter.ChangeMonth += _moveOperationsUCPresenter_ChangeMonth;
            _moveOperationsUCPresenter.ChangeYear += _moveOperationsUCPresenter_ChangeYear;
            
            
        }

        void _moveOperationsUCPresenter_ChangeYear(object sender, EventArgs e)
        {
            if (!_searchOperationsUCPresenter.FlagFilteringActivate)
                _searchOperationsUCPresenter.LastSearchedYear = (int)sender;
            int year = _searchOperationsUCPresenter.LastSearchedYear;
            int month = _searchOperationsUCPresenter.LastSearchedMonth;
            string term = _searchOperationsUCPresenter.LastSearchedTerm;
            _searchOperationsUCPresenter.SearchInList(year, month, term);
        }

        void _moveOperationsUCPresenter_ChangeMonth(object sender, EventArgs e)
        {
            if(!_searchOperationsUCPresenter.FlagFilteringActivate)
                _searchOperationsUCPresenter.LastSearchedMonth = (int)sender;
            int year = _searchOperationsUCPresenter.LastSearchedYear;
            int month = (int)sender;//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            string term = _searchOperationsUCPresenter.LastSearchedTerm;
            _searchOperationsUCPresenter.SearchInList(year, month, term);
        }

        void _searchOperationsUCPresenter_ReFiltering(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.FilterOperations();
           
        }

        void _gridOperationsUCPresenter_ActivateFilter(object sender, EventArgs e)
        {
            int filterMonthFrom = (_gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedMonths().Count > 0) ? _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedMonths()[0] : 1;
            int filterYearFrom = _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetRistrectedYears()[0];
            _searchOperationsUCPresenter.StandardSearch(filterYearFrom, filterMonthFrom, "");
            _searchOperationsUCPresenter.FlagFilteringActivate = true;
            _searchOperationsUCPresenter.FlagSearchInDB = false;
            _searchOperationsUCPresenter.GetUC.SetVisibilityButtonFilter = true;
            _searchOperationsUCPresenter.ListFullOperations = ((List<FullOperation>)sender);
            _moveOperationsUCPresenter.GetUC.Month = _searchOperationsUCPresenter.LastSearchedMonth.ToString();
            _moveOperationsUCPresenter.ListYear = _searchOperationsUCPresenter.ListFullOperations.Select(o => o.date.Year).Distinct().ToList();
        }

        void _searchOperationsUCPresenter_ShowFilterOperationUC(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.GetUC.GetAsidePanel.Visible = true;
            ((UserControl)_gridOperationsUCPresenter.GetFilterOperationsUCPresenter.GetUC).BringToFront();
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.ProvideBeneficiareDataSource();
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.ProvideImputationDataSource();
            //_gridOperationsUCPresenter.GetNewOperationPresenter.ResetOperationForm();
        }

        void _gridOperationsUCPresenter_EndOfSaveOperation(object sender, EventArgs e)
        {
            int year = int.Parse(_moveOperationsUCPresenter.GetUC.Year);
            int month = int.Parse(_moveOperationsUCPresenter.GetUC.Month);
            string term = _searchOperationsUCPresenter.LastSearchedTerm;
            _searchOperationsUCPresenter.Refresh(year,month, term);
            _gridOperationsUCPresenter.GetUC.GetAsidePanel.Visible = false;

        }

        void _operationsUC_InitializeUCsValues(object sender, EventArgs e)
        {
            _searchOperationsUCPresenter.IdAccountLoggin = IdCompte;
            _searchOperationsUCPresenter.SearchInDataBase(DateTime.Now.Year, DateTime.Now.Month, "");
            _gridOperationsUCPresenter.GetNewOperationPresenter.ProvideBeneficiareDataSource();
            _gridOperationsUCPresenter.GetNewOperationPresenter.ProvideImputationDataSource();
            _gridOperationsUCPresenter.GetNewOperationPresenter.IdAccount = IdCompte;
            _gridOperationsUCPresenter.IdCompte = IdCompte;
            _gridOperationsUCPresenter.GetFilterOperationsUCPresenter.idCompte = IdCompte;
        }

        void _searchOperationsUCPresenter_ShowAddNewOperationUC(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.GetUC.GetAsidePanel.Visible = true;
            ((UserControl)_gridOperationsUCPresenter.GetNewOperationPresenter.GetUC).BringToFront();
            _gridOperationsUCPresenter.GetNewOperationPresenter.GetUC.Title = "Ajouter";
            _gridOperationsUCPresenter.GetNewOperationPresenter.ResetOperationForm();
            
        }

        void _searchOperationsUCPresenter_QuickSearchEnd(object sender, EventArgs e)
        {
            _gridOperationsUCPresenter.ProvideDgvDataSource((List<FullOperation>)sender);
            _moveOperationsUCPresenter.GetUC.Month = _searchOperationsUCPresenter.LastSearchedMonth.ToString();
            _moveOperationsUCPresenter.GetUC.Year = _searchOperationsUCPresenter.LastSearchedYear.ToString();
        }

        private void SetUserControlsToPanel()
        {           
            _searchOperationsUCPresenter.GetUC.SetParent(_operationsUC.GetTopPanel);
            _gridOperationsUCPresenter.GetUC.SetParent(_operationsUC.GetMiddlePanel);
            _moveOperationsUCPresenter.GetUC.SetParent(_operationsUC.GetBottomPanel);
            

        }
    }
}
