namespace CaisseWinformUI.Views.UserControls
{
    partial class MoveOperationsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveOperationsUC));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCountOfMonth = new System.Windows.Forms.Label();
            this.btnPreviousYear = new System.Windows.Forms.Button();
            this.btnNextYear = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNextYear);
            this.panel2.Controls.Add(this.lblYear);
            this.panel2.Controls.Add(this.btnPreviousYear);
            this.panel2.Controls.Add(this.lblCountOfMonth);
            this.panel2.Controls.Add(this.btnNextMonth);
            this.panel2.Controls.Add(this.btnPreviousMonth);
            this.panel2.Controls.Add(this.lblMonth);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 50);
            this.panel2.TabIndex = 1;
            // 
            // lblCountOfMonth
            // 
            this.lblCountOfMonth.AutoSize = true;
            this.lblCountOfMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountOfMonth.Location = new System.Drawing.Point(33, 13);
            this.lblCountOfMonth.Name = "lblCountOfMonth";
            this.lblCountOfMonth.Size = new System.Drawing.Size(43, 21);
            this.lblCountOfMonth.TabIndex = 6;
            this.lblCountOfMonth.Text = "1/10";
            // 
            // btnPreviousYear
            // 
            this.btnPreviousYear.AutoSize = true;
            this.btnPreviousYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousYear.FlatAppearance.BorderSize = 0;
            this.btnPreviousYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousYear.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousYear.Image")));
            this.btnPreviousYear.Location = new System.Drawing.Point(279, 9);
            this.btnPreviousYear.Name = "btnPreviousYear";
            this.btnPreviousYear.Size = new System.Drawing.Size(30, 30);
            this.btnPreviousYear.TabIndex = 5;
            this.btnPreviousYear.UseVisualStyleBackColor = true;
            // 
            // btnNextYear
            // 
            this.btnNextYear.AutoSize = true;
            this.btnNextYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextYear.FlatAppearance.BorderSize = 0;
            this.btnNextYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextYear.Image = ((System.Drawing.Image)(resources.GetObject("btnNextYear.Image")));
            this.btnNextYear.Location = new System.Drawing.Point(367, 9);
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.Size = new System.Drawing.Size(30, 30);
            this.btnNextYear.TabIndex = 4;
            this.btnNextYear.UseVisualStyleBackColor = true;
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.AutoSize = true;
            this.btnNextMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextMonth.FlatAppearance.BorderSize = 0;
            this.btnNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnNextMonth.Image")));
            this.btnNextMonth.Location = new System.Drawing.Point(225, 8);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(30, 31);
            this.btnNextMonth.TabIndex = 3;
            this.btnNextMonth.UseVisualStyleBackColor = true;
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.AutoSize = true;
            this.btnPreviousMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousMonth.FlatAppearance.BorderSize = 0;
            this.btnPreviousMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousMonth.Image")));
            this.btnPreviousMonth.Location = new System.Drawing.Point(164, 8);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(30, 31);
            this.btnPreviousMonth.TabIndex = 1;
            this.btnPreviousMonth.UseVisualStyleBackColor = true;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(200, 13);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(19, 21);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "1";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(315, 14);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(46, 21);
            this.lblYear.TabIndex = 8;
            this.lblYear.Text = "2019";
            // 
            // MoveOperationsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MoveOperationsUC";
            this.Size = new System.Drawing.Size(809, 50);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.Button btnPreviousYear;
        private System.Windows.Forms.Button btnNextYear;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Label lblCountOfMonth;
        private System.Windows.Forms.Label lblYear;
    }
}
