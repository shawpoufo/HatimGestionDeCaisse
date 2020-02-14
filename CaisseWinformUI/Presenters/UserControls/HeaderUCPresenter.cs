using CaisseLogicLibrary.DataAccess.AccountDataAccess;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class HeaderUCPresenter : CaisseWinformUI.Presenters.UserControls.IHeaderUCPresenter
    {
        private IHeaderUC _headerUC;
        private IAccountData _accountData;
        public IHeaderUC GetUC { get { return _headerUC; } }
        public int IdAccount { get; set; }

        public HeaderUCPresenter(IHeaderUC headerUC,IAccountData accountData)
        {
            _headerUC = headerUC;
            _accountData = accountData;
            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _headerUC.InitializeValues += _headerUC_InitializeValues;
        }

        void _headerUC_InitializeValues(object sender, EventArgs e)
        {
            RefreshAccountAmount();
        }
        public void RefreshAccountAmount()
        {
            _headerUC.Solde =  _accountData.Amount(IdAccount).ToString()+" MAD";
        }
    }
}
