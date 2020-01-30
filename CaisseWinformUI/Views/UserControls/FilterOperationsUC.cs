using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseDTOsLibrary.Models.BeneficiaireModel;

namespace CaisseWinformUI.Views.UserControls
{
    public partial class FilterOperationsUC : UserControl, CaisseWinformUI.Views.UserControls.IFilterOperationsUC
    {
        public string GetDateFrom { get { return txtDateFrom.Text.Trim(); } }
        public string GetDateTo { get { return txtDateTo.Text.Trim(); } }
        public ComboBox GetCbxImputations { get { return cbxImputation; } }
        public ComboBox GetCbxBeneficiarys { get { return cbxBeneficiaire; } }
        public ComboBox GetCbxSelectedImputations { get { return cbxSelectedImputations; } }
        public ComboBox GetCbxSelectedBeneficiarys { get { return cbxSelectedBeneficiarys; } }
        public string SetErrorDateMessage { set { lblErrorDate.Text = value; } }
        public Label LabelErrorImputation { get { return lblErrorImputation; } }
        public Label LabelErrorBeneficiary { get { return lblErrorBeneficiary; } }
        public string Libelles { get { return txtLibelles.Text.Trim(); } }
        public event EventHandler Filter;
        public event EventHandler AddSelectedImputation;
        public event EventHandler RemoveSelectedImputation;
        public event EventHandler AddSelectedBeneficiary;
        public event EventHandler RemoveSelectedBeneficiary;

        public FilterOperationsUC()
        {
            InitializeComponent();
            this.Load += FilterOperationsUC_Load;
        }

        void FilterOperationsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            cbxBeneficiaire.ValueMember = "id";
            cbxBeneficiaire.DisplayMember = "libelle";

            cbxImputation.ValueMember = "id";
            cbxImputation.DisplayMember = "libelle";

            cbxSelectedImputations.ValueMember = "id";
            cbxSelectedImputations.DisplayMember = "libelle";

            cbxSelectedBeneficiarys.ValueMember = "id";
            cbxSelectedBeneficiarys.DisplayMember = "libelle";
            
            InitializeEvents();
        }
        private void InitializeEvents()
        {
            cbxImputation.KeyPress += cbxImputation_KeyPress;
            cbxBeneficiaire.KeyPress += cbxBeneficiaire_KeyPress;
            cbxSelectedBeneficiarys.KeyPress += cbxSelectedBeneficiarys_KeyPress;
            cbxSelectedImputations.KeyPress += cbxSelectedImputations_KeyPress;
            txtDateFrom.KeyPress += txtDateFrom_KeyPress;
            txtDateTo.KeyPress += txtDateTo_KeyPress;
            lblSave.Click += lblSave_Click;

            btnAddImputation.Click += btnAddImputation_Click;
            btnRemoveImputation.Click += btnRemoveImputation_Click;
            btnAddBeneficiairy.Click += btnAddBeneficiairy_Click;
            btnRemoveBeneficiairy.Click += btnRemoveBeneficiairy_Click;
        }


        void btnRemoveBeneficiairy_Click(object sender, EventArgs e)
        {
            if (RemoveSelectedBeneficiary != null)
                RemoveSelectedBeneficiary(this, EventArgs.Empty);
        }

        void btnAddBeneficiairy_Click(object sender, EventArgs e)
        {
            if (AddSelectedBeneficiary != null)
                AddSelectedBeneficiary(this, EventArgs.Empty);
        }

        void btnRemoveImputation_Click(object sender, EventArgs e)
        {
            if (RemoveSelectedImputation != null)
                RemoveSelectedImputation(this, EventArgs.Empty);
        }

        void btnAddImputation_Click(object sender, EventArgs e)
        {
            if (AddSelectedImputation != null)
                AddSelectedImputation(this, EventArgs.Empty);
        }

        

        void lblSave_Click(object sender, EventArgs e)
        {
            if (Filter != null)
                Filter(this, EventArgs.Empty);
        }

        void txtDateTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        void txtDateFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        void cbxBeneficiaire_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxBeneficiaire.DroppedDown = false;
        }

        void cbxImputation_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxImputation.DroppedDown = false;
        }
        void cbxSelectedImputations_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxSelectedImputations.DroppedDown = false;
        }

        void cbxSelectedBeneficiarys_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxSelectedBeneficiarys.DroppedDown = false;
        }


        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
