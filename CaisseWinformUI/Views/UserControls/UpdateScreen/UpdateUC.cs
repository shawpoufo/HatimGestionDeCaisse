using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Views.UserControls.UpdateScreen
{
    public partial class UpdateUC : UserControl, CaisseWinformUI.Views.UserControls.UpdateScreen.IUpdateUC
    {
        public bool Loading { set { pBLoading.Visible = value; } }

        public UpdateUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
