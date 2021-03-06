﻿using System;
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
    public partial class LoginUC : UserControl, ILoginUC
    {
        public event EventHandler Login;
        public event EventHandler SignUp;
        public string GetUsername { get { return txtUsername.Text; } }
        public string GetPassword { get { return txtPassword.Text; } }
        public string SetErrorMessage { set { lblErrorMessage.Text = value; } }
        public string Version { set { lblVersion.Text = value; } }

        public LoginUC()
        {
            InitializeComponent();
            this.Load += LoginUC_Load;
            InitializeEvents();
            
            
        }

        void LoginUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            
        }

        

        private void InitializeEvents()
        {
            btnLogin.Click += btnLogin_Click;
            btnInscription.Click += btnInscription_Click;
            txtUsername.KeyDown += txtUsername_KeyDown;
            txtPassword.KeyDown += txtPassword_KeyDown;
        }

        void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (Login != null)
                    Login(this, e);
            }
        }

        void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (Login != null)
                    Login(this, e);
            }
        }



        void btnInscription_Click(object sender, EventArgs e)
        {
            if (SignUp != null)
                SignUp(this, e);
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (Login != null)
                Login(this, e);
            
        }
        public void ResetUC()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            lblErrorMessage.Text = "";
        }


        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
    }
}
