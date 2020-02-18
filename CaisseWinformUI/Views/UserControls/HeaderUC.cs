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
    public partial class HeaderUC : UserControl,IHeaderUC
    {
        public string Solde { get { return lblSolde.Text; } set { lblSolde.Text = value; } }
        public event EventHandler InitializeValues;
        public event EventHandler ShowOperationsUC;
        public event EventHandler ShowManageUC;
        public HeaderUC()
        {
            InitializeComponent();
            this.Load += HeaderUC_Load;
            InitializeEvents();
            this.Dock = DockStyle.Fill;
            this.Height = 130;
        }

        void HeaderUC_Load(object sender, EventArgs e)
        {
            
            if (InitializeValues != null)
                InitializeValues(this, EventArgs.Empty);
        }
        private void InitializeEvents()
        {
            LblOperations.Click += LblOperations_Click;
            LblManger.Click += LblManger_Click;
            LblRapports.Click += LblRapports_Click;
        }

        void LblRapports_Click(object sender, EventArgs e)
        {
            MoveThePanel(LblRapports);
            ChangeLabelColor(LblRapports);
        }

        void LblManger_Click(object sender, EventArgs e)
        {
            MoveThePanel(LblManger);
            ChangeLabelColor(LblManger);
            if (ShowManageUC != null)
                ShowManageUC(null, EventArgs.Empty);
        }

        void LblOperations_Click(object sender, EventArgs e)
        {
            MoveThePanel(LblOperations);
            ChangeLabelColor(LblOperations);
            if (ShowOperationsUC != null)
                ShowOperationsUC(null, EventArgs.Empty);
        }

        private void MoveThePanel(Label label)
        {
            MovePanel.Width = label.Width;

            int Y = MovePanel.Location.Y;
            int X = label.Location.X;
            MovePanel.Location = new Point(X, Y);
        }

        private void ChangeLabelColor(Label label)
        {
            List<Label> listLabel = new List<Label>();

            listLabel.Add(LblManger);
            listLabel.Add(LblOperations);
            listLabel.Add(LblRapports);

            listLabel.Where(l => l.Name != label.Name).ToList().ForEach(l => l.ForeColor = Color.Silver);
            listLabel.Where(l => l.Name == label.Name).ToList().FirstOrDefault().ForeColor = Color.White;
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
