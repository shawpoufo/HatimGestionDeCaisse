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
using System.Globalization;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace CaisseWinformUI.Views.UserControls
{
    public partial class AddNewOperationUC : UserControl, CaisseWinformUI.Views.UserControls.IAddNewOperationUC
    {
        public event EventHandler SaveOperation;
        public event EventHandler CancelNewOperation;

        public string Date { get { return txtDate.Text.Trim(); } set { txtDate.Text = value; } }
        public int IdImputation { get { return Convert.ToInt32(cbxImputation.SelectedValue); } set { cbxImputation.SelectedValue = value; } }
        public string GetTextImputation { get { return cbxImputation.Text.Trim(); } }
        public string Increment { get { return txtIncrement.Text.Trim(); } set { txtIncrement.Text = value; } }
        public string Decrement { get { return txtDecrement.Text.Trim(); } set { txtDecrement.Text = value; } }
        public int IdBeneficiaire { get { return Convert.ToInt32(cbxBeneficiaire.SelectedValue); } set { cbxBeneficiaire.SelectedValue = value; } }
        public string GetTextBeneficiaire { get { return cbxBeneficiaire.Text.Trim(); } }
        public string Libelle { get { return txtLibelle.Text.Trim(); } set { txtLibelle.Text = value; } }
        public IEnumerable<IImputation> SetImputationDataSource { set { cbxImputation.DataSource = value; } }
        public IEnumerable<IBeneficiaire> SetBeneficiaireDataSource { set { cbxBeneficiaire.DataSource = value; } }
        public string Title { set { lblTitle.Text = value; } }

        private string oldIncrement;
        private string oldDecrement;
        
        public AddNewOperationUC()
        {
            InitializeComponent();
            this.Load += AddNewOperationUC_Load;
            oldIncrement = "";
            oldDecrement = "";
            InitializeEvents();
        }

        void AddNewOperationUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            

            cbxBeneficiaire.ValueMember = "id";
            cbxBeneficiaire.DisplayMember = "libelle";

            cbxImputation.ValueMember = "id";
            cbxImputation.DisplayMember = "libelle";
        }

        private void InitializeEvents()
        {
            btnAddNew.Click += btnAddNew_Click;
            btnCancel.Click += btnCancel_Click;
            txtIncrement.KeyPress += txtIncrement_KeyPress;
            txtDecrement.KeyPress += txtDecrement_KeyPress;
            txtIncrement.TextChanged += txtIncrement_TextChanged;
            txtDecrement.TextChanged += txtDecrement_TextChanged;
            txtDate.KeyPress += txtDate_KeyPress;
            cbxImputation.KeyPress += cbxImputation_KeyPress;
            cbxBeneficiaire.KeyPress += cbxBeneficiaire_KeyPress;
      
        }


        void txtDecrement_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text.Trim();

            if (Regex.IsMatch(text, @"^\d+\.?(\d+)?$") || string.IsNullOrEmpty(text))
            {
                oldDecrement = txtDecrement.Text.Trim();
            }
            else
            {
                txtDecrement.Text = oldDecrement;
            }
        }

        void txtIncrement_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text.Trim();

            if (Regex.IsMatch(text, @"^\d+\.?(\d+)?$") || string.IsNullOrEmpty(text))
            {
                oldIncrement = txtIncrement.Text.Trim();
            }
            else
            {
                txtIncrement.Text = oldIncrement;
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

        void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '/') )
            {
                e.Handled = true;    
                
            }
        }

        void txtDecrement_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorAmount.Text = "";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || ((TextBox)sender).Text.Contains('.')) || (e.KeyChar == '.' && string.IsNullOrEmpty(((TextBox)sender).Text.Trim())))
            {
                e.Handled = true;

            }
        }

        void txtIncrement_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorAmount.Text = "";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || ((TextBox)sender).Text.Contains('.')) || (e.KeyChar == '.' && string.IsNullOrEmpty(((TextBox)sender).Text.Trim())))
            {
                e.Handled = true;

            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelNewOperation != null)
                CancelNewOperation(this, EventArgs.Empty);
        }

        void btnAddNew_Click(object sender, EventArgs e)
        {
            if (SaveOperation != null)
                SaveOperation(this, EventArgs.Empty);
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
        public void SetErrorMessage(List<ValidationFailure> errors)
        {
            
            foreach(var control in this.Controls)
            {
                if(control is Label)
                {
                    
                    if(((Label)control).Name.ToLower().Contains("error"))
                    {

                        foreach(var error in errors)
                        {
                            if (((Label)control).Name.ToLower().Contains(error.PropertyName.ToLower()))
                            {
                                ((Label)control).Text = error.ErrorMessage;
                                break;
                            }
                            else
                                ((Label)control).Text = "";
                        }
                                         
                    }
                }
            }

        }
         
    }
}
