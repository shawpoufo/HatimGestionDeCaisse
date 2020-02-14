namespace CaisseWinformUI.Views.UserControls
{
    partial class GridOperationsUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TotalPanel = new System.Windows.Forms.Panel();
            this.lblIncrement = new System.Windows.Forms.Label();
            this.lblDecrement = new System.Windows.Forms.Label();
            this.totalGeneral = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOperations = new System.Windows.Forms.DataGridView();
            this.asidePanel = new System.Windows.Forms.Panel();
            this.TotalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            this.SuspendLayout();
            // 
            // TotalPanel
            // 
            this.TotalPanel.BackColor = System.Drawing.Color.White;
            this.TotalPanel.Controls.Add(this.lblIncrement);
            this.TotalPanel.Controls.Add(this.lblDecrement);
            this.TotalPanel.Controls.Add(this.totalGeneral);
            this.TotalPanel.Controls.Add(this.label1);
            this.TotalPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TotalPanel.Location = new System.Drawing.Point(0, 288);
            this.TotalPanel.Name = "TotalPanel";
            this.TotalPanel.Size = new System.Drawing.Size(674, 45);
            this.TotalPanel.TabIndex = 1;
            // 
            // lblIncrement
            // 
            this.lblIncrement.AutoSize = true;
            this.lblIncrement.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncrement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(185)))), ((int)(((byte)(197)))));
            this.lblIncrement.Location = new System.Drawing.Point(260, 9);
            this.lblIncrement.Name = "lblIncrement";
            this.lblIncrement.Size = new System.Drawing.Size(22, 25);
            this.lblIncrement.TabIndex = 5;
            this.lblIncrement.Text = "0";
            this.lblIncrement.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDecrement
            // 
            this.lblDecrement.AutoSize = true;
            this.lblDecrement.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecrement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(100)))));
            this.lblDecrement.Location = new System.Drawing.Point(430, 9);
            this.lblDecrement.Name = "lblDecrement";
            this.lblDecrement.Size = new System.Drawing.Size(22, 25);
            this.lblDecrement.TabIndex = 4;
            this.lblDecrement.Text = "0";
            this.lblDecrement.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalGeneral
            // 
            this.totalGeneral.AutoSize = true;
            this.totalGeneral.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalGeneral.ForeColor = System.Drawing.Color.Black;
            this.totalGeneral.Location = new System.Drawing.Point(80, 9);
            this.totalGeneral.Name = "totalGeneral";
            this.totalGeneral.Size = new System.Drawing.Size(22, 25);
            this.totalGeneral.TabIndex = 3;
            this.totalGeneral.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total";
            // 
            // dgvOperations
            // 
            this.dgvOperations.AllowUserToAddRows = false;
            this.dgvOperations.AllowUserToDeleteRows = false;
            this.dgvOperations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(217)))), ((int)(((byte)(229)))));
            this.dgvOperations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOperations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOperations.ColumnHeadersHeight = 20;
            this.dgvOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperations.GridColor = System.Drawing.Color.Gray;
            this.dgvOperations.Location = new System.Drawing.Point(0, 0);
            this.dgvOperations.MultiSelect = false;
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperations.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOperations.RowHeadersVisible = false;
            this.dgvOperations.RowHeadersWidth = 47;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvOperations.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOperations.RowTemplate.Height = 60;
            this.dgvOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperations.Size = new System.Drawing.Size(674, 288);
            this.dgvOperations.TabIndex = 2;
            // 
            // asidePanel
            // 
            this.asidePanel.AutoScroll = true;
            this.asidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.asidePanel.Location = new System.Drawing.Point(200, 0);
            this.asidePanel.Name = "asidePanel";
            this.asidePanel.Size = new System.Drawing.Size(474, 288);
            this.asidePanel.TabIndex = 0;
            // 
            // GridOperationsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.asidePanel);
            this.Controls.Add(this.dgvOperations);
            this.Controls.Add(this.TotalPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GridOperationsUC";
            this.Size = new System.Drawing.Size(674, 333);
            this.TotalPanel.ResumeLayout(false);
            this.TotalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TotalPanel;
        private System.Windows.Forms.DataGridView dgvOperations;
        private System.Windows.Forms.Panel asidePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalGeneral;
        private System.Windows.Forms.Label lblIncrement;
        private System.Windows.Forms.Label lblDecrement;

    }
}
