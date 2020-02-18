using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CaisseWinformUI.Views.UserControls.DownLoad;

namespace CaisseWinformUI.Views.UserControls
{
    public partial class SearchOperationsUC : UserControl, CaisseWinformUI.Views.UserControls.ISearchOperationsUC
    {
        public event EventHandler QuickSearch;
        public event EventHandler Filter;
        public event EventHandler NewOperation;
        public event EventHandler Refresh;
        public event EventHandler ShowDownLoadUC;
        public bool SetVisibilityLabelFilter { set { lblFilter.Visible = value; } }
        private string oldYear;

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
            InitializeEvents();
            oldYear = "";
            
        }

        void txtYear_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text.Trim();

            if (Regex.IsMatch(text, @"^\d*$") || string.IsNullOrEmpty(text))
            {
                oldYear = txtYear.Text.Trim();
            }
            else
            {
                txtYear.Text = oldYear;
            }
        }

        void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void SearchOperationsUC_Load(object sender, EventArgs e)
        {
            
            
            this.Dock = DockStyle.Fill;
            lblFilter.Visible = false;
            
        }


        private void InitializeEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnNew.Click += btnNew_Click;
            btnFilter.Click += btnFiltre_Click;
            txtYear.KeyPress += txtYear_KeyPress;
            txtYear.TextChanged += txtYear_TextChanged;
            btnDownLoad.Click += btnDownLoad_Click;
            txtYear.KeyDown += txtYear_KeyDown;
            txtSearch.KeyDown += txtSearch_KeyDown;
        }

        void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (QuickSearch != null)
                    QuickSearch(this, EventArgs.Empty);
            }
        }

        void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (QuickSearch != null)
                    QuickSearch(this, EventArgs.Empty);
            }
        }

        void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (ShowDownLoadUC != null)
                ShowDownLoadUC(sender, EventArgs.Empty);
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
                txtYear.Text = "";
                lblErrorYear.Text = "";
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
