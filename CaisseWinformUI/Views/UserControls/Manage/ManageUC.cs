using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Views.UserControls.Manage
{
    public partial class ManageUC : UserControl, CaisseWinformUI.Views.UserControls.Manage.IManageUC
    {
        public int GetIdUpdateImputation { get { return Convert.ToInt32(cbxImputation.SelectedValue); } }
        public int GetIdUpdateBeneficiary { get { return Convert.ToInt32(cbxBeneficiary.SelectedValue); } }
        public string LibelleImputation { get { return txtUpdateImputation.Text.ToLower().Trim(); } set { txtUpdateImputation.Text = value; } }
        public string LibelleBeneficiary { get { return txtUpdateBeneficiary.Text.ToLower().Trim(); } set { txtUpdateBeneficiary.Text = value; } }
        public string SetErrorMessageImputationLibelle { set { lblErrorLibelleImputation.Text = value; } }
        public string SetErrorMessageImputationList { set { lblErrorListImputation.Text = value; } }
        public string SetErrorMessageBeneficiaryLibelle { set { lblErrorLibelleBeneficiary.Text = value; } }
        public string SetErrorMessageBeneficiaryList { set { lblErrorListBeneficiary.Text = value; } }
        public object SetDataSourceImputation { set { cbxImputation.DataSource = value; } }
        public object SetDataSourceBeneficiary { set { cbxBeneficiary.DataSource = value; } }
        public event EventHandler UpdateImputation;
        public event EventHandler UpdateBeneficiary;

        public ManageUC()
        {
            InitializeComponent();
            this.Load +=ManageUC_Load;
            this.Dock = DockStyle.Fill;
        }

        void ManageUC_Load(object sender, EventArgs e)
        {
            InitializeEvents();
            CbxMembers();
        }

        private void InitializeEvents()
        {
            btnUpdateBeneficiary.Click += btnUpdateBeneficiary_Click;
            btnUpdateImputation.Click += btnUpdateImputation_Click;
            cbxImputation.SelectedIndexChanged += cbxImputation_SelectedIndexChanged;
            cbxBeneficiary.SelectedIndexChanged += cbxBeneficiary_SelectedIndexChanged;
        }

        void cbxBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBeneficiary.SelectedIndex <= 0)
                lblErrorListBeneficiary.Text = "Veuillez choisire un beneficiaire";
            else
                lblErrorListBeneficiary.Text = "";
        }

        void cbxImputation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxImputation.SelectedIndex <= 0)
                lblErrorListImputation.Text = "Veuillez choisire une imputation";
            else
                lblErrorListImputation.Text = "";
        }
        private void CbxMembers()
        {
            cbxBeneficiary.ValueMember = "id";
            cbxBeneficiary.DisplayMember = "libelle";

            cbxImputation.ValueMember = "id";
            cbxImputation.DisplayMember = "libelle";
        }

        void btnUpdateImputation_Click(object sender, EventArgs e)
        {
            if(UpdateImputation != null)
            {
                UpdateImputation(null, EventArgs.Empty);
            }
        }

        void btnUpdateBeneficiary_Click(object sender, EventArgs e)
        {
            if(UpdateBeneficiary !=null)
            {
                UpdateBeneficiary(null, EventArgs.Empty);
            }
        }


        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
            
        }
    }
}
