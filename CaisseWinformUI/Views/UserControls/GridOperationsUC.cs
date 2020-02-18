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
        public string TotalGeneral { get { return totalGeneral.Text; } set { totalGeneral.Text = value; } }
        public string Decrement { get { return lblDecrement.Text; } set { lblDecrement.Text = value; } }
        public string Increment { get { return lblIncrement.Text; } set { lblIncrement.Text = value; } }
        public event EventHandler ShowEditOperation;
        public event EventHandler ShowMessageDeleteOpeartion;

        public GridOperationsUC()
        {
            InitializeComponent();
            this.Load += GridOperationsUC_Load;
            InitializeEvents(); 
        }

        void GridOperationsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;         
            asidePanel.Visible = false;
            asidePanel.Width = 500;

  
        }

        public void SetParent(Panel parentPanel)
        {
            Parent = parentPanel;
        }
        private void InitializeEvents()
        {
            dgvOperations.CellContentClick += dgvOperations_CellContentClick;
            dgvOperations.CellMouseLeave += dgvOperations_CellMouseLeave;
            dgvOperations.CellMouseEnter += dgvOperations_CellMouseEnter;
            
        }


        void dgvOperations_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex, senderGrid))
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    senderGrid.Cursor = Cursors.Hand;
                }
            }
        }

        void dgvOperations_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            
            var senderGrid = (DataGridView)sender;

            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex, senderGrid))
            {
                senderGrid.Cursor = Cursors.Default;
            }
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex, DataGridView dgv)
        {
            return rowIndex >= 0 && rowIndex < dgv.RowCount &&
                columnIndex >= 0 && columnIndex <= dgv.ColumnCount;
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

                if (senderGrid.Columns[e.ColumnIndex].Name == "deleteOperation")
                {
                    if (ShowMessageDeleteOpeartion != null)
                        ShowMessageDeleteOpeartion(senderGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), EventArgs.Empty);
                }

            }


            
        }


    }
}
