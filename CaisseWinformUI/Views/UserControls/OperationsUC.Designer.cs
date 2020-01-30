namespace CaisseWinformUI.Views.UserControls
{
    partial class OperationsUC
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(6);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(321, 128);
            this.topPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoScroll = true;
            this.bottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 128);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(6);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(321, 56);
            this.bottomPanel.TabIndex = 1;
            // 
            // middlePanel
            // 
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middlePanel.Location = new System.Drawing.Point(0, 184);
            this.middlePanel.Margin = new System.Windows.Forms.Padding(6);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(321, 183);
            this.middlePanel.TabIndex = 2;
            // 
            // OperationsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OperationsUC";
            this.Size = new System.Drawing.Size(321, 367);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel middlePanel;
    }
}
