namespace CaisseWinformUI.Views.UserControls
{
    partial class FilterOperationsUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.cbxImputation = new System.Windows.Forms.ComboBox();
            this.cbxSelectedImputations = new System.Windows.Forms.ComboBox();
            this.cbxBeneficiaire = new System.Windows.Forms.ComboBox();
            this.cbxSelectedBeneficiarys = new System.Windows.Forms.ComboBox();
            this.txtLibelles = new System.Windows.Forms.TextBox();
            this.lblSave = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblErrorDate = new System.Windows.Forms.Label();
            this.lblErrorImputation = new System.Windows.Forms.Label();
            this.lblErrorBeneficiary = new System.Windows.Forms.Label();
            this.lblExemplLibelle = new System.Windows.Forms.Label();
            this.btnAddImputation = new System.Windows.Forms.Button();
            this.btnRemoveImputation = new System.Windows.Forms.Button();
            this.btnRemoveBeneficiairy = new System.Windows.Forms.Button();
            this.btnAddBeneficiairy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Du";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(277, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Au";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(277, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Choisie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Imputation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(277, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Choisie";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(22, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Bénéficicare";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(22, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "Libelle";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateFrom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFrom.Location = new System.Drawing.Point(22, 110);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(167, 26);
            this.txtDateFrom.TabIndex = 9;
            // 
            // txtDateTo
            // 
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTo.Location = new System.Drawing.Point(277, 110);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(167, 26);
            this.txtDateTo.TabIndex = 10;
            // 
            // cbxImputation
            // 
            this.cbxImputation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxImputation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxImputation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxImputation.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxImputation.FormattingEnabled = true;
            this.cbxImputation.Location = new System.Drawing.Point(22, 218);
            this.cbxImputation.Name = "cbxImputation";
            this.cbxImputation.Size = new System.Drawing.Size(167, 33);
            this.cbxImputation.TabIndex = 11;
            // 
            // cbxSelectedImputations
            // 
            this.cbxSelectedImputations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSelectedImputations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSelectedImputations.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxSelectedImputations.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSelectedImputations.FormattingEnabled = true;
            this.cbxSelectedImputations.Location = new System.Drawing.Point(277, 218);
            this.cbxSelectedImputations.Name = "cbxSelectedImputations";
            this.cbxSelectedImputations.Size = new System.Drawing.Size(167, 33);
            this.cbxSelectedImputations.TabIndex = 12;
            // 
            // cbxBeneficiaire
            // 
            this.cbxBeneficiaire.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxBeneficiaire.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxBeneficiaire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBeneficiaire.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBeneficiaire.FormattingEnabled = true;
            this.cbxBeneficiaire.Location = new System.Drawing.Point(22, 333);
            this.cbxBeneficiaire.Name = "cbxBeneficiaire";
            this.cbxBeneficiaire.Size = new System.Drawing.Size(167, 33);
            this.cbxBeneficiaire.TabIndex = 13;
            // 
            // cbxSelectedBeneficiarys
            // 
            this.cbxSelectedBeneficiarys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSelectedBeneficiarys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSelectedBeneficiarys.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxSelectedBeneficiarys.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSelectedBeneficiarys.FormattingEnabled = true;
            this.cbxSelectedBeneficiarys.Location = new System.Drawing.Point(277, 332);
            this.cbxSelectedBeneficiarys.Name = "cbxSelectedBeneficiarys";
            this.cbxSelectedBeneficiarys.Size = new System.Drawing.Size(167, 33);
            this.cbxSelectedBeneficiarys.TabIndex = 14;
            // 
            // txtLibelles
            // 
            this.txtLibelles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLibelles.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLibelles.Location = new System.Drawing.Point(20, 462);
            this.txtLibelles.Multiline = true;
            this.txtLibelles.Name = "txtLibelles";
            this.txtLibelles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLibelles.Size = new System.Drawing.Size(422, 56);
            this.txtLibelles.TabIndex = 15;
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(218)))), ((int)(((byte)(192)))));
            this.lblSave.Location = new System.Drawing.Point(355, 18);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(104, 25);
            this.lblSave.TabIndex = 16;
            this.lblSave.Text = "Enregistrer";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(16, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 21);
            this.label11.TabIndex = 17;
            this.label11.Text = "Annuler";
            // 
            // lblErrorDate
            // 
            this.lblErrorDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(62)))), ((int)(((byte)(123)))));
            this.lblErrorDate.Location = new System.Drawing.Point(22, 144);
            this.lblErrorDate.Name = "lblErrorDate";
            this.lblErrorDate.Size = new System.Drawing.Size(422, 37);
            this.lblErrorDate.TabIndex = 18;
            this.lblErrorDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblErrorImputation
            // 
            this.lblErrorImputation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorImputation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(62)))), ((int)(((byte)(123)))));
            this.lblErrorImputation.Location = new System.Drawing.Point(22, 259);
            this.lblErrorImputation.Name = "lblErrorImputation";
            this.lblErrorImputation.Size = new System.Drawing.Size(422, 37);
            this.lblErrorImputation.TabIndex = 23;
            this.lblErrorImputation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblErrorBeneficiary
            // 
            this.lblErrorBeneficiary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorBeneficiary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(62)))), ((int)(((byte)(123)))));
            this.lblErrorBeneficiary.Location = new System.Drawing.Point(22, 374);
            this.lblErrorBeneficiary.Name = "lblErrorBeneficiary";
            this.lblErrorBeneficiary.Size = new System.Drawing.Size(422, 37);
            this.lblErrorBeneficiary.TabIndex = 24;
            this.lblErrorBeneficiary.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblExemplLibelle
            // 
            this.lblExemplLibelle.AutoSize = true;
            this.lblExemplLibelle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExemplLibelle.ForeColor = System.Drawing.Color.Gray;
            this.lblExemplLibelle.Location = new System.Drawing.Point(23, 442);
            this.lblExemplLibelle.Name = "lblExemplLibelle";
            this.lblExemplLibelle.Size = new System.Drawing.Size(147, 17);
            this.lblExemplLibelle.TabIndex = 25;
            this.lblExemplLibelle.Text = "ex : libelle 1 ; libelle 2 ...";
            // 
            // btnAddImputation
            // 
            this.btnAddImputation.AutoSize = true;
            this.btnAddImputation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddImputation.FlatAppearance.BorderSize = 0;
            this.btnAddImputation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImputation.Image = global::CaisseWinformUI.Properties.Resources.rightArrow;
            this.btnAddImputation.Location = new System.Drawing.Point(223, 188);
            this.btnAddImputation.Name = "btnAddImputation";
            this.btnAddImputation.Size = new System.Drawing.Size(30, 30);
            this.btnAddImputation.TabIndex = 26;
            this.btnAddImputation.UseVisualStyleBackColor = true;
            // 
            // btnRemoveImputation
            // 
            this.btnRemoveImputation.AutoSize = true;
            this.btnRemoveImputation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveImputation.FlatAppearance.BorderSize = 0;
            this.btnRemoveImputation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveImputation.Image = global::CaisseWinformUI.Properties.Resources.leftArrow;
            this.btnRemoveImputation.Location = new System.Drawing.Point(223, 224);
            this.btnRemoveImputation.Name = "btnRemoveImputation";
            this.btnRemoveImputation.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveImputation.TabIndex = 27;
            this.btnRemoveImputation.UseVisualStyleBackColor = true;
            // 
            // btnRemoveBeneficiairy
            // 
            this.btnRemoveBeneficiairy.AutoSize = true;
            this.btnRemoveBeneficiairy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveBeneficiairy.FlatAppearance.BorderSize = 0;
            this.btnRemoveBeneficiairy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveBeneficiairy.Image = global::CaisseWinformUI.Properties.Resources.leftArrow;
            this.btnRemoveBeneficiairy.Location = new System.Drawing.Point(223, 338);
            this.btnRemoveBeneficiairy.Name = "btnRemoveBeneficiairy";
            this.btnRemoveBeneficiairy.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveBeneficiairy.TabIndex = 29;
            this.btnRemoveBeneficiairy.UseVisualStyleBackColor = true;
            // 
            // btnAddBeneficiairy
            // 
            this.btnAddBeneficiairy.AutoSize = true;
            this.btnAddBeneficiairy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBeneficiairy.FlatAppearance.BorderSize = 0;
            this.btnAddBeneficiairy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBeneficiairy.Image = global::CaisseWinformUI.Properties.Resources.rightArrow;
            this.btnAddBeneficiairy.Location = new System.Drawing.Point(223, 302);
            this.btnAddBeneficiairy.Name = "btnAddBeneficiairy";
            this.btnAddBeneficiairy.Size = new System.Drawing.Size(30, 30);
            this.btnAddBeneficiairy.TabIndex = 28;
            this.btnAddBeneficiairy.UseVisualStyleBackColor = true;
            // 
            // FilterOperationsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.btnRemoveBeneficiairy);
            this.Controls.Add(this.btnAddBeneficiairy);
            this.Controls.Add(this.btnRemoveImputation);
            this.Controls.Add(this.btnAddImputation);
            this.Controls.Add(this.lblExemplLibelle);
            this.Controls.Add(this.lblErrorBeneficiary);
            this.Controls.Add(this.lblErrorImputation);
            this.Controls.Add(this.lblErrorDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.txtLibelles);
            this.Controls.Add(this.cbxSelectedBeneficiarys);
            this.Controls.Add(this.cbxBeneficiaire);
            this.Controls.Add(this.cbxSelectedImputations);
            this.Controls.Add(this.cbxImputation);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FilterOperationsUC";
            this.Size = new System.Drawing.Size(474, 551);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.ComboBox cbxImputation;
        private System.Windows.Forms.ComboBox cbxSelectedImputations;
        private System.Windows.Forms.ComboBox cbxBeneficiaire;
        private System.Windows.Forms.ComboBox cbxSelectedBeneficiarys;
        private System.Windows.Forms.TextBox txtLibelles;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblErrorDate;
        private System.Windows.Forms.Label lblErrorImputation;
        private System.Windows.Forms.Label lblErrorBeneficiary;
        private System.Windows.Forms.Label lblExemplLibelle;
        private System.Windows.Forms.Button btnAddImputation;
        private System.Windows.Forms.Button btnRemoveImputation;
        private System.Windows.Forms.Button btnRemoveBeneficiairy;
        private System.Windows.Forms.Button btnAddBeneficiairy;
    }
}
