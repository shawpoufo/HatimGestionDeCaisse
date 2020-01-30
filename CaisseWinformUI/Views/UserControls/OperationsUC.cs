using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Views.UserControls
{
    public partial class OperationsUC : UserControl,IOperationsUC
    {
        public Panel GetTopPanel { get { return topPanel; } }
        public Panel GetMiddlePanel { get { return middlePanel; } }
        public Panel GetBottomPanel { get { return bottomPanel; } }
        public event EventHandler InitializeUCsValues;

        public OperationsUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += OperationsUC_Load;
        }

        void OperationsUC_Load(object sender, EventArgs e)
        {
            topPanel.Height = 119;
            //middlePanel.Height = 500;
            bottomPanel.Height = 40;
            if (InitializeUCsValues != null)
                InitializeUCsValues(this, EventArgs.Empty);
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
