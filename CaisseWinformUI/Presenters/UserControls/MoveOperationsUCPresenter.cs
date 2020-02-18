using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class MoveOperationsUCPresenter : CaisseWinformUI.Presenters.UserControls.IMoveOperationsUCPresenter
    {
        private IMoveOperationsUC _moveOperationsUC;
        public IMoveOperationsUC GetUC { get { return _moveOperationsUC; } }
        public List<int> ListYear { get; set; }
        public List<int> ListRestrictedMonths { get; set; }
        public event EventHandler ChangeMonth;
        public event EventHandler ChangeYear;
        

        public MoveOperationsUCPresenter(IMoveOperationsUC moveOperationsUC)
        {
            _moveOperationsUC = moveOperationsUC;
            ListYear = new List<int>();
            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _moveOperationsUC.ChangeMonthValue += _moveOperationsUC_ChangeMonthValue;
            _moveOperationsUC.ChangeYearValue += _moveOperationsUC_ChangeYearValue;
            _moveOperationsUC.InitializeUCValues += _moveOperationsUC_InitializeUCValues;
        }

        void _moveOperationsUC_InitializeUCValues(object sender, EventArgs e)
        {
            _moveOperationsUC.Month = DateTime.Now.Month.ToString();
            _moveOperationsUC.Year = DateTime.Now.Year.ToString();
        }

        void _moveOperationsUC_ChangeYearValue(object sender, EventArgs e)
        {
            //         
            //int newYear = ((bool)sender) ? ++currentYear : --currentYear;
            //_moveOperationsUC.Year = newYear.ToString();
            //if (ChangeYear != null)
            //    ChangeYear(newYear, EventArgs.Empty); 
            int currentYear = Convert.ToInt32(_moveOperationsUC.Year);
            int indexCurrentYear = ListYear.FindIndex(y => y == currentYear);

            if((bool)sender)
            {
                if(indexCurrentYear < ListYear.Count -1)
                    indexCurrentYear++;
            }
            else
            {
                if(indexCurrentYear > 0)
                    indexCurrentYear--;
            }

            int newYear = ListYear[indexCurrentYear];
            _moveOperationsUC.Year = newYear.ToString();

            if (indexCurrentYear == 0)
                _moveOperationsUC.Month = ListRestrictedMonths.First().ToString();
            else
                _moveOperationsUC.Month = "1";
            
            if (ChangeYear != null)
                ChangeYear(newYear, EventArgs.Empty);
            
        }

        void _moveOperationsUC_ChangeMonthValue(object sender, EventArgs e)
        {
            int currentMonth = Convert.ToInt32(_moveOperationsUC.Month);
            int currentYear = Convert.ToInt32(_moveOperationsUC.Year);

            if (ListRestrictedMonths != null && ListRestrictedMonths.Count > 1)
            {
                
                if ((bool)sender)
                {
                    if (currentMonth < 12)
                    {
                        if (currentMonth != ListRestrictedMonths[1] || currentYear != ListYear[ListYear.Count - 1])
                            currentMonth++;
                    }

                }
                else
                {
                    if (currentMonth > 1)
                    {
                        if (currentMonth != ListRestrictedMonths[0] || currentYear != ListYear[0])
                        currentMonth--;
                    }
                }
            }
            else
            {
                if ((bool)sender)
                {
                    if (currentMonth < 12)
                        currentMonth++;

                }
                else
                {
                    if (currentMonth > 1)
                        currentMonth--;
                }
            }
            
            _moveOperationsUC.Month = currentMonth.ToString();
            if (ChangeMonth != null)
                ChangeMonth(currentMonth, EventArgs.Empty);
            
            
        }

    }
}
