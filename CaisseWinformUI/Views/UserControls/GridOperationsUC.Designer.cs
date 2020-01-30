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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOperations = new System.Windows.Forms.DataGridView();
            this.asidePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 45);
            this.panel2.TabIndex = 1;
            // 
            // dgvOperations
            // 
            this.dgvOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperations.Location = new System.Drawing.Point(0, 0);
            this.dgvOperations.Name = "dgvOperations";
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
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.asidePanel);
            this.Controls.Add(this.dgvOperations);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GridOperationsUC";
            this.Size = new System.Drawing.Size(674, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOperations;
        private System.Windows.Forms.Panel asidePanel;

    }
}
