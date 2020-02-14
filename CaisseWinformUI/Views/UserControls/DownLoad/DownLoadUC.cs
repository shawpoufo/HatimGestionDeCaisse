using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopupControl;

namespace CaisseWinformUI.Views.UserControls.DownLoad
{
    public partial class DownLoadUC : UserControl, IDownLoadUC
    {
        public event EventHandler DownLoad;
        public bool FileNameRequired { set { lblFileNameRequired.Visible = value; } }
        public bool Loading { set { pbLoading.Visible = value; } }
        public string FileName { set { txtFileName.Text = value; } }
        public DownLoadUC()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = new Size(Size.Width * 2, Size.Height * 2);
            DoubleBuffered = true;
            ResizeRedraw = true;
            lblFileNameRequired.Visible = false;
            pbLoading.Visible = false;
            btnDownLoad.Click += btnDownLoad_Click;
        }

        void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (DownLoad != null)
                DownLoad(txtFileName.Text.Trim(),EventArgs.Empty);
        }

        protected override void WndProc(ref Message m)
        {
            if ((Parent as Popup).ProcessResizing(ref m))
            {
                return;
            }
            base.WndProc(ref m);
        }

    }
}
