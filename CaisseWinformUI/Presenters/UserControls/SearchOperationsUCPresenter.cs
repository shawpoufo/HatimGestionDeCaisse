using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseLogicLibrary.DataAccess.SearchOperations;
using CaisseWinformUI.Presenters.UserControls.DownLoad;
using CaisseWinformUI.Views.UserControls;
using CaisseWinformUI.Views.UserControls.DownLoad;
using PopupControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class SearchOperationsUCPresenter : CaisseWinformUI.Presenters.UserControls.ISearchOperationsUCPresenter
    {
        private ISearchOperationsUC _searchOperationsUC;
        public ISearchOperationsUC GetUC { get { return _searchOperationsUC; } }
        public IEnumerable<IFullOperation> ListFullOperations { get; set; }      
        private ISearchOperation _searchOperation;
        private IDownLoadUCPresenter _downLoadUCPresenter;
        public IDownLoadUCPresenter GetdownLoadUCPresenter { get { return _downLoadUCPresenter; } }
        public bool FlagFilteringActivate{get;set;}
        public bool FlagSearchInDB{get;set;}
        public int LastSearchedYear { get; set; }
        public int LastSearchedMonth { get; set; }
        public string LastSearchedTerm { get; set; }
        public int IdAccountLoggin { get; set; }
        public event EventHandler ProvideDataSource;
        public event EventHandler ShowAddNewOperationUC;
        public event EventHandler ShowFilterOperationUC;
        public event EventHandler ReFiltering;
        public event EventHandler FilterDeactivated;
        private Popup popup;

        public SearchOperationsUCPresenter(ISearchOperationsUC searchOperationsUC, ISearchOperation searchOperation, IDownLoadUCPresenter downLoadUCPresenter)
        {
            _searchOperationsUC = searchOperationsUC;
            _searchOperation = searchOperation;
            _downLoadUCPresenter = downLoadUCPresenter;
            FlagFilteringActivate = false;
            FlagSearchInDB = false;
            LastSearchedYear = DateTime.Now.Year;
            LastSearchedMonth = DateTime.Now.Month;
            LastSearchedTerm = "";
            popup = new Popup((DownLoadUC)_downLoadUCPresenter.GetUC);
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _searchOperationsUC.QuickSearch += _searchOperationsUC_QuickSearch;
            _searchOperationsUC.Refresh += _searchOperationsUC_Refresh;
            _searchOperationsUC.NewOperation += _searchOperationsUC_NewOperation;
            _searchOperationsUC.Filter += _searchOperationsUC_Filter;
            _searchOperationsUC.ShowDownLoadUC += _searchOperationsUC_ShowDownLoadUC;
        }


        void _searchOperationsUC_ShowDownLoadUC(object sender, EventArgs e)
        {        
            popup.Show(sender as Button);

        }
        public void HideDownLoadUC()
        {
            popup.Hide();
        }

        void _searchOperationsUC_Filter(object sender, EventArgs e)
        {
            if (ShowFilterOperationUC != null)
                ShowFilterOperationUC(true, EventArgs.Empty);
        }

        void _searchOperationsUC_NewOperation(object sender, EventArgs e)
        {
            if (ShowAddNewOperationUC != null)
                ShowAddNewOperationUC(this, EventArgs.Empty);
        }

        void _searchOperationsUC_Refresh(object sender, EventArgs e)
        {          
            DeactivateFilter();
            Refresh(LastSearchedYear, LastSearchedMonth, LastSearchedTerm);
        }

        void _searchOperationsUC_QuickSearch(object sender, EventArgs e)
        {

            if (_searchOperationsUC.GetYear > 0)
            {

                DeactivateFilter();

                StandardSearch(_searchOperationsUC.GetYear, 1, _searchOperationsUC.GetTerm.ToLower());

                SearchInDataBase(_searchOperationsUC.GetYear, 1, _searchOperationsUC.GetTerm.ToLower());
                //if (FlagFilteringActivate || ListFullOperations.Count() <= 0 || _searchOperationsUC.GetYear != ListFullOperations.First().date.Year)
                //{
                    
                //    DeactivateFilter();
                    
                //    StandardSearch(_searchOperationsUC.GetYear, 1, _searchOperationsUC.GetTerm.ToLower());

                //    SearchInDataBase(_searchOperationsUC.GetYear, 1,_searchOperationsUC.GetTerm.ToLower());
                //}
                //else 
                //{
                //    StandardSearch(LastSearchedYear, 1, _searchOperationsUC.GetTerm.ToLower());
                //    SearchInList(_searchOperationsUC.GetYear, LastSearchedMonth, _searchOperationsUC.GetTerm.ToLower());

                //}

            }
        }
        private void DeactivateFilter()
        {
            _searchOperationsUC.SetVisibilityLabelFilter = false;
            FlagFilteringActivate = false;
            StandardSearch(DateTime.Now.Year, DateTime.Now.Month, "");
            if (FilterDeactivated != null)
                FilterDeactivated(null, EventArgs.Empty);
        }

        public void SearchInList(int year, int month, string term)
        {
            var temporaryList = new List<FullOperation>();
            
            temporaryList = ListFullOperations.Where(o => o.date.Year == year && o.date.Month == month).Cast<FullOperation>().ToList();

            if (!string.IsNullOrEmpty(term))
                temporaryList = SearchTerm(temporaryList, term);

            if (ProvideDataSource != null)
                ProvideDataSource(temporaryList.Cast<FullOperation>().ToList(), EventArgs.Empty); 
        }
        public void SearchInDataBase(int year, int month, string term)
        {
            ListFullOperations = _searchOperation.QuickSearch(year, term, IdAccountLoggin);

            if (ProvideDataSource != null)
                ProvideDataSource(ListFullOperations.Cast<FullOperation>().Where(o => o.date.Month == month).ToList(), EventArgs.Empty); 
        }
        public bool DifferentYears()
        {
            return ListFullOperations.Any(o => o.date.Year != ListFullOperations.First().date.Year);
                 
        }
        private List<FullOperation> SearchTerm(List<FullOperation> records, string term)
        {

                 term = _searchOperationsUC.GetTerm.ToLower();
                 return records.Where(o => o.imputation.ToLower().Contains(term)
                                                                || o.beneficiaire.ToLower().Contains(term)
                                                                || o.libelle.ToLower().Contains(term))
                                                                .ToList();
        }
        public void Refresh(int year, int month, string term)
        {
            if (FlagFilteringActivate)
            {
                if (ReFiltering != null)
                    ReFiltering(null, EventArgs.Empty);
                SearchInList(year, month, term);
            }
            else
            {
                SearchInDataBase(year,month, term);

            }
        }
        public void StandardSearch(int year,int month,string term)
        {
            LastSearchedYear = year;
            LastSearchedMonth = month;
            LastSearchedTerm = term;
        }
        public  IEnumerable<IFullOperation> GetExceptedMonthOperation()
        {
            return _searchOperation.QuickSearch(LastSearchedYear - 1, LastSearchedTerm, IdAccountLoggin).Where(o => o.date.Month == 12);
        }
    }
}
