using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseWinformUI.Presenters.UserControls;
using CaisseWinformUI.Views;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Presenters
{
    public class MainViewPresenter : IMainViewPresenter
    {
        private IMainView _mainView;
        public IMainView GetView { get { return _mainView; } }
        private IHeaderUCPresenter _headerUCPresenter;
        public ILoginAccount _loginAccount { get; set; }
        private IOperationsUCPresenter _operationsUCPresenter;

        public MainViewPresenter(IMainView mainView, IOperationsUCPresenter operationsUCPresenter, IHeaderUCPresenter headerUCPresenter)
        {
            _mainView = mainView;
            _headerUCPresenter = headerUCPresenter;
            _operationsUCPresenter = operationsUCPresenter;
            SetUserControlsPanel();

        }

        private void SetUserControlsPanel()
        {
            _headerUCPresenter.GetUC.SetParent(_mainView.GetHeaderPanel);
            _operationsUCPresenter.GetUC.SetParent(_mainView.GetBodyPanel);
        }
        public void SendIdAccountToOperationUC()
        {
            _operationsUCPresenter.IdCompte = _loginAccount.id;
        }
    }
}
