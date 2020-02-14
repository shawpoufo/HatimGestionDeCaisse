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
    public partial class SignUpUC : UserControl,ISignUpUC
    {
        public event EventHandler Login;
        public event EventHandler SignUp;
        public string GetUsername { get { return txtUsername.Text; } }
        public string GetPassword { get { return txtPassword.Text; } }
        public string GetEmail{ get { return txtEmail.Text; } }
        public string SetErrorMessage { set { lblErrorMessage.Text = value; } }
        public Color SetColorErrorMessage { set { lblErrorMessage.ForeColor = value; } }

        public SignUpUC()
        {
            InitializeComponent();
            this.Load += SignUpUC_Load;
        }

        void SignUpUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnInscription.Click += btnInscription_Click;
            btnLogin.Click += btnLogin_Click;
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login != null)
                Login(sender, e);
        }

        void btnInscription_Click(object sender, EventArgs e)
        {
            ResetUC();
            if (SignUp != null)
                SignUp(sender, e);
        }
        private void ResetUC()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            lblErrorMessage.Text = "";
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
