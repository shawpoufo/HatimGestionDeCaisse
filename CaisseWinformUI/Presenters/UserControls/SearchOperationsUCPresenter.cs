using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseLogicLibrary.DataAccess.SearchOperations;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class SearchOperationsUCPresenter : CaisseWinformUI.Presenters.UserControls.ISearchOperationsUCPresenter
    {
        private ISearchOperationsUC _searchOperationsUC;
        public ISearchOperationsUC GetUC { get { return _searchOperationsUC; } }
        public IEnumerable<IFullOperation> ListFullOperations { get; set; }      
        private ISearchOperation _searchOperation;
        public bool FlagFilteringActivate{get;set;}
        public bool FlagSearchInDB{get;set;}
        public int LastSearchedYear { get; set; }
        public int LastSearchedMonth { get; set; }
        public string LastSearchedTerm { get; set; }
        public int IdAccountLoggin { get; set; }
        public event EventHandler QuickSearchEnd;
        public event EventHandler ShowAddNewOperationUC;
        public event EventHandler ShowFilterOperationUC;
        public event EventHandler ReFiltering;

        public SearchOperationsUCPresenter(ISearchOperationsUC searchOperationsUC, ISearchOperation searchOperation)
        {
            _searchOperationsUC = searchOperationsUC;
            _searchOperation = searchOperation;
            FlagFilteringActivate = false;
            FlagSearchInDB = false;
            LastSearchedYear = DateTime.Now.Year;
            LastSearchedMonth = DateTime.Now.Month;
            LastSearchedTerm = "";
            
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _searchOperationsUC.QuickSearch += _searchOperationsUC_QuickSearch;
            _searchOperationsUC.Refresh += _searchOperationsUC_Refresh;
            _searchOperationsUC.NewOperation += _searchOperationsUC_NewOperation;
            _searchOperationsUC.Filter += _searchOperationsUC_Filter;
            _searchOperationsUC.DeactivateFilter += _searchOperationsUC_DeactivateFilter;
        }

        void _searchOperationsUC_DeactivateFilter(object sender, EventArgs e)
        {
            _searchOperationsUC.SetVisibilityButtonFilter = false;
            FlagFilteringActivate = false;
            FlagSearchInDB = true;
            StandardSearch(DateTime.Now.Year,DateTime.Now.Month,"");
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
            //if (FlagFilteringActivate)
            //    StandardSearch(0, 1, "");
            //else
            if (!FlagFilteringActivate)
                StandardSearch(DateTime.Now.Year, DateTime.Now.Month,"");

            Refresh(LastSearchedYear, LastSearchedMonth, LastSearchedTerm);
        }

        void _searchOperationsUC_QuickSearch(object sender, EventArgs e)
        {

            if (_searchOperationsUC.GetYear > 0)
            {
                

                if (FlagSearchInDB || ListFullOperations.Count() <= 0)
                {
                    StandardSearch(_searchOperationsUC.GetYear, 1, _searchOperationsUC.GetTerm.ToLower());
                    SearchInDataBase(_searchOperationsUC.GetYear, 1,_searchOperationsUC.GetTerm.ToLower());

                    if (FlagSearchInDB)
                        FlagSearchInDB = false;
                }
                else if (!FlagFilteringActivate && (DifferentYears() || _searchOperationsUC.GetYear != ListFullOperations.First().date.Year))
                {
                    StandardSearch(_searchOperationsUC.GetYear, 1, _searchOperationsUC.GetTerm.ToLower());
                    SearchInDataBase(_searchOperationsUC.GetYear,1,_searchOperationsUC.GetTerm.ToLower());
                }
                else 
                {
                    StandardSearch(LastSearchedYear, LastSearchedMonth, _searchOperationsUC.GetTerm.ToLower());
                    SearchInList(_searchOperationsUC.GetYear, LastSearchedMonth, _searchOperationsUC.GetTerm.ToLower());

                }

            }
        }

        public void SearchInList(int year, int month, string term)
        {
            var temporaryList = new List<IFullOperation>();
            
            temporaryList = ListFullOperations.Where(o => o.date.Year == year && o.date.Month == month).ToList();

            if (!string.IsNullOrEmpty(term))
                temporaryList = SearchTerm(temporaryList, term);

            if (QuickSearchEnd != null)
                QuickSearchEnd(temporaryList.Cast<FullOperation>().ToList(), EventArgs.Empty); 
        }
        public void SearchInDataBase(int year, int month, string term)
        {
            ListFullOperations = _searchOperation.QuickSearch(year, term, IdAccountLoggin);

            if (QuickSearchEnd != null)
                QuickSearchEnd(ListFullOperations.Cast<FullOperation>().Where(o => o.date.Month == month).ToList(), EventArgs.Empty); 
        }
        public bool DifferentYears()
        {
            return ListFullOperations.Any(o => o.date.Year != ListFullOperations.First().date.Year);
                 
        }
        private List<IFullOperation> SearchTerm(List<IFullOperation> records, string term)
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
                if(year != LastSearchedYear || month != LastSearchedMonth || term !=LastSearchedTerm)
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
        
    }
}
