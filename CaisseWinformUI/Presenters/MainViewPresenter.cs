using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseWinformUI.Presenters.UserControls;
using CaisseWinformUI.Presenters.UserControls.Manage;
using CaisseWinformUI.Views;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Presenters
{
    public class MainViewPresenter : IMainViewPresenter
    {
        private IMainView _mainView;
        public IMainView GetView { get { return _mainView; } }
        private IHeaderUCPresenter _headerUCPresenter;
        public ILoginAccount _loginAccount { get; set; }
        private IOperationsUCPresenter _operationsUCPresenter;
        private IManageUCPresenter _manageUCPresenter;
        public event EventHandler BackToLoginView;

        public MainViewPresenter(IMainView mainView, IOperationsUCPresenter operationsUCPresenter, IHeaderUCPresenter headerUCPresenter, IManageUCPresenter manageUCPresenter)
        {
            _mainView = mainView;
            _headerUCPresenter = headerUCPresenter;
            _operationsUCPresenter = operationsUCPresenter;
            _manageUCPresenter = manageUCPresenter;
            SetUserControlsPanel();
            SubscribeToEventsSetup();
            
        }
        private void SubscribeToEventsSetup()
        {
            _operationsUCPresenter.RefreshAccount += _operationsUCPresenter_RefreshAccount;
            _headerUCPresenter.GetUC.ShowManageUC += GetUC_ShowManageUC;
            _headerUCPresenter.GetUC.ShowOperationsUC += GetUC_ShowOperationsUC;
            _mainView.MainViewClosed += _mainView_MainViewClosed;
        }

        void _mainView_MainViewClosed(object sender, EventArgs e)
        {
            if (BackToLoginView != null)
                BackToLoginView(null, EventArgs.Empty);
        }

        void GetUC_ShowOperationsUC(object sender, EventArgs e)
        {
            ((UserControl)_operationsUCPresenter.GetUC).BringToFront();
        }

        void GetUC_ShowManageUC(object sender, EventArgs e)
        {
            _manageUCPresenter.IdAccount = _loginAccount.id;
            ((UserControl)_manageUCPresenter.GetUC).BringToFront();
            _manageUCPresenter.ResetUC();
            
        }

        void _operationsUCPresenter_RefreshAccount(object sender, EventArgs e)
        {
            _headerUCPresenter.RefreshAccountAmount();
        }
        private void SetUserControlsPanel()
        {
            _headerUCPresenter.GetUC.SetParent(_mainView.GetHeaderPanel);
            _operationsUCPresenter.GetUC.SetParent(_mainView.GetBodyPanel);
            _manageUCPresenter.GetUC.SetParent(_mainView.GetBodyPanel);
        }
        public void SendIdAccount()
        {
            _operationsUCPresenter.IdCompte = _loginAccount.id;
            _headerUCPresenter.IdAccount = _loginAccount.id;
        }
    }
}
