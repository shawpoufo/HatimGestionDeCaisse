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
        }

        void _moveOperationsUC_ChangeYearValue(object sender, EventArgs e)
        {
            //int currentYear = Convert.ToInt32(_moveOperationsUC.Year);          
            //int newYear = ((bool)sender) ? ++currentYear : --currentYear;
            //_moveOperationsUC.Year = newYear.ToString();
            //if (ChangeYear != null)
            //    ChangeYear(newYear, EventArgs.Empty); 
            
            
        }

        void _moveOperationsUC_ChangeMonthValue(object sender, EventArgs e)
        {
            int currentMonth = Convert.ToInt32(_moveOperationsUC.Month);           
            if((bool)sender)
            {
                if (currentMonth < 12)
                    currentMonth++;
                    
            }
            else
            {
                if (currentMonth > 1)
                    currentMonth--;
            }
            _moveOperationsUC.Month = currentMonth.ToString();
            if (ChangeMonth != null)
                ChangeMonth(currentMonth, EventArgs.Empty);
            
            
        }

    }
}
