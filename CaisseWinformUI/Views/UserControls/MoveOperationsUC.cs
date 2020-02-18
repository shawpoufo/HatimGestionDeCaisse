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
    public partial class MoveOperationsUC : UserControl, CaisseWinformUI.Views.UserControls.IMoveOperationsUC
    {
        public string Month { get { return lblMonth.Text.Trim(); } set { lblMonth.Text = value; } }
        public string Year { get { return lblYear.Text.Trim(); } set { lblYear.Text = value; } }
        public string CountOperation { get { return lblCountOperation.Text; } set { lblCountOperation.Text = value; } }
        public event EventHandler InitializeUCValues;
        public bool ButtonsMoveYearVisibility 
        {
            set 
            {
                btnPreviousYear.Visible = value;
                btnNextYear.Visible = value; 
            }
        }

        public event EventHandler ChangeMonthValue;
        public event EventHandler ChangeYearValue;


        public MoveOperationsUC()
        {
            InitializeComponent();
            this.Load += MoveOperationsUC_Load;
            InitializeEvents();
            
        }


        async void MoveOperationsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;          
            btnNextYear.Visible = false;
            btnPreviousYear.Visible = false;
            if (InitializeUCValues != null)
               await Task.Run(()=>  InitializeUCValues(null, EventArgs.Empty));
            
            
            

        }
        private void InitializeEvents()
        {
            btnPreviousMonth.Click += btnPreviousMonth_Click;
            btnNextMonth.Click += btnNextMonth_Click;
            btnNextYear.Click += btnNextYear_Click;
            btnPreviousYear.Click += btnPreviousYear_Click;
            
        }

        void btnPreviousYear_Click(object sender, EventArgs e)
        {
            if (ChangeYearValue != null)
                ChangeYearValue(false, EventArgs.Empty);
        }

        void btnNextYear_Click(object sender, EventArgs e)
        {
            if (ChangeYearValue != null)
                ChangeYearValue(true, EventArgs.Empty);
        }

        void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            if (ChangeMonthValue != null)
                ChangeMonthValue(false, EventArgs.Empty);
        }

        void btnNextMonth_Click(object sender, EventArgs e)
        {
            if (ChangeMonthValue != null)
                ChangeMonthValue(true, EventArgs.Empty);
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
