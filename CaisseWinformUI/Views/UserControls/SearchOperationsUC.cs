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
    public partial class SearchOperationsUC : UserControl, CaisseWinformUI.Views.UserControls.ISearchOperationsUC
    {
        public event EventHandler QuickSearch;
        public event EventHandler Filter;
        public event EventHandler NewOperation;
        public event EventHandler Refresh;
        public event EventHandler DeactivateFilter;
        public bool SetVisibilityButtonFilter { set { btnActiveFiltre.Visible = value; } }

        public int GetYear
        {
            get
            {
                if (string.IsNullOrEmpty(txtYear.Text.Trim()))
                {
                    lblErrorYear.Text = "Ce champ est obligatoire";              
                }
                else if(Convert.ToInt32(txtYear.Text.Trim()) <= 0)
                {
                    lblErrorYear.Text = "Veuillez entrer une année valide";
                }
                else
                {
                    lblErrorYear.Text = "";
                    return Convert.ToInt32(txtYear.Text.Trim());
                }
                return 0;
            }
        }
        public string GetTerm
        {
            get
            {
                return txtSearch.Text.Trim();
            }
        }
        public SearchOperationsUC()
        {
            InitializeComponent();
            this.Load += SearchOperationsUC_Load;
        }

        void SearchOperationsUC_Load(object sender, EventArgs e)
        {
            
            InitializeEvents();
            this.Dock = DockStyle.Fill;
            btnActiveFiltre.Visible = false;
        }

        private void InitializeEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnNew.Click += btnNew_Click;
            btnFilter.Click += btnFiltre_Click;
            btnActiveFiltre.Click += btnActiveFiltre_Click;
        }

        void btnActiveFiltre_Click(object sender, EventArgs e)
        {

            if (DeactivateFilter != null)
                DeactivateFilter(null,EventArgs.Empty);
            
        }

        void btnFiltre_Click(object sender, EventArgs e)
        {
            if (Filter != null)
                Filter(this, EventArgs.Empty);
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            if (NewOperation != null)
                NewOperation(this, EventArgs.Empty);
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            if (Refresh != null)
            {
                txtSearch.Text = "";
                Refresh(this, EventArgs.Empty);
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            if (QuickSearch != null)
                QuickSearch(this, EventArgs.Empty);
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }

    }
}
