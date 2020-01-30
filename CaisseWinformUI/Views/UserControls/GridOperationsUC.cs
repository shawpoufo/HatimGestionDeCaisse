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
    public partial class GridOperationsUC : UserControl,IGridOperationsUC
    {
        public DataGridView GetDGV { get { return dgvOperations; } }
        public Panel GetAsidePanel { get { return asidePanel; } }
        public event EventHandler ShowEditOperation;
        public GridOperationsUC()
        {
            InitializeComponent();
            this.Load += GridOperationsUC_Load;
        }

        void GridOperationsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;         
            this.asidePanel.Visible = false;
            InitializeEvents();   
            
            
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
        private void InitializeEvents()
        {
            dgvOperations.CellContentClick += dgvOperations_CellContentClick;
        }

        void dgvOperations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "editOperation")
                {
                    if (ShowEditOperation != null)
                        ShowEditOperation(senderGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), EventArgs.Empty);
                }


            }
            
        }
    }
}
