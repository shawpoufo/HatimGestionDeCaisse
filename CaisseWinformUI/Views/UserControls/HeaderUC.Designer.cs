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
            this.lblSolde = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblOperations = new System.Windows.Forms.Label();
            this.LblRapports = new System.Windows.Forms.Label();
            this.LblManger = new System.Windows.Forms.Label();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblSolde);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(819, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 100);
            this.panel3.TabIndex = 2;
            // 
            // lblSolde
            // 
            this.lblSolde.AutoSize = true;
            this.lblSolde.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolde.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblSolde.Location = new System.Drawing.Point(78, 60);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(0, 25);
            this.lblSolde.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "SOLDE";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 100);
            this.panel5.TabIndex = 2;
            // 
            // LblOperations
            // 
            this.LblOperations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblOperations.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOperations.ForeColor = System.Drawing.Color.White;
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
            this.LblManger.Text = "Gestion";
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
            // label2
            // 
            this.label2.Image = global::CaisseWinformUI.Properties.Resources.walletIcon;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 40);
            this.label2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CaisseWinformUI.Properties.Resources.logoIcon;
            this.pictureBox1.Location = new System.Drawing.Point(46, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HeaderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
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
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblOperations;
        private System.Windows.Forms.Label LblRapports;
        private System.Windows.Forms.Label LblManger;
        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblSolde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
