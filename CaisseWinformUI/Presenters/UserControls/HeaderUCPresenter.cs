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
        public IHeaderUC GetUC { get { return _headerUC; } }

        public HeaderUCPresenter(IHeaderUC headerUC)
        {
            _headerUC = headerUC;
        }
    }
}
