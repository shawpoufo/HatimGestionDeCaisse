using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Views
{
    public partial class MainView : Form,IMainView
    {

        public Panel GetHeaderPanel { get { return HeaderPanel; } }
        public Panel GetBodyPanel { get { return BodyPanel; } }
        public event EventHandler MainViewClosed;

        public MainView()
        {
            InitializeComponent();
            this.Load += MainView_Load;
        }

        void MainView_Load(object sender, EventArgs e)
        {
            InitializeViewProperties();

            
        }

        void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MainViewClosed != null)
                MainViewClosed(null, EventArgs.Empty);
        }

        private void InitializeEvents()
        {

        }

        private void InitializeViewProperties()
        {
            this.MinimumSize = new Size(1200, 850);
            this.Size = new Size(1200, 850);
            this.FormClosed += MainView_FormClosed;
            this.CenterToScreen();

            HeaderPanel.Height = 100;

        }
    }
}
