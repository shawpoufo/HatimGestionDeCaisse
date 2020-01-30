namespace CaisseWinformUI.Views.UserControls
{
    partial class HeaderUC
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblOperations = new System.Windows.Forms.Label();
            this.LblRapports = new System.Windows.Forms.Label();
            this.LblManger = new System.Windows.Forms.Label();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(819, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 100);
            this.panel3.TabIndex = 2;
            // 
            // LblOperations
            // 
            this.LblOperations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblOperations.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOperations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.LblOperations.Location = new System.Drawing.Point(230, 61);
            this.LblOperations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblOperations.Name = "LblOperations";
            this.LblOperations.Size = new System.Drawing.Size(100, 31);
            this.LblOperations.TabIndex = 3;
            this.LblOperations.Text = "Operations";
            this.LblOperations.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblRapports
            // 
            this.LblRapports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblRapports.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRapports.ForeColor = System.Drawing.Color.Silver;
            this.LblRapports.Location = new System.Drawing.Point(349, 61);
            this.LblRapports.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRapports.Name = "LblRapports";
            this.LblRapports.Size = new System.Drawing.Size(100, 31);
            this.LblRapports.TabIndex = 4;
            this.LblRapports.Text = "Rapports";
            this.LblRapports.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblManger
            // 
            this.LblManger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblManger.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblManger.ForeColor = System.Drawing.Color.Silver;
            this.LblManger.Location = new System.Drawing.Point(468, 61);
            this.LblManger.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblManger.Name = "LblManger";
            this.LblManger.Size = new System.Drawing.Size(100, 31);
            this.LblManger.TabIndex = 5;
            this.LblManger.Text = "Manager";
            this.LblManger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MovePanel
            // 
            this.MovePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.MovePanel.Location = new System.Drawing.Point(230, 95);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(100, 5);
            this.MovePanel.TabIndex = 6;
            // 
            // HeaderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MovePanel);
            this.Controls.Add(this.LblManger);
            this.Controls.Add(this.LblRapports);
            this.Controls.Add(this.LblOperations);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HeaderUC";
            this.Size = new System.Drawing.Size(1075, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblOperations;
        private System.Windows.Forms.Label LblRapports;
        private System.Windows.Forms.Label LblManger;
        private System.Windows.Forms.Panel MovePanel;

    }
}
