namespace WindowsFormsAppGMmatos
{
    partial class FormMateriel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gridMateriel = new System.Windows.Forms.DataGridView();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtCategorie = new System.Windows.Forms.TextBox();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.numPrix = new System.Windows.Forms.NumericUpDown();
            this.cboEtat = new System.Windows.Forms.ComboBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.lblPrix = new System.Windows.Forms.Label();
            this.lblEtat = new System.Windows.Forms.Label();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridMateriel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrix)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMateriel
            // 
            this.gridMateriel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMateriel.Location = new System.Drawing.Point(12, 12);
            this.gridMateriel.Name = "gridMateriel";
            this.gridMateriel.Size = new System.Drawing.Size(760, 250);
            this.gridMateriel.TabIndex = 0;
            this.gridMateriel.SelectionChanged += new System.EventHandler(this.gridMateriel_SelectionChanged);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(12, 280);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(57, 13);
            this.lblReference.Text = "Référence";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(90, 277);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(140, 20);
            this.txtReference.TabIndex = 1;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Location = new System.Drawing.Point(250, 280);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(63, 13);
            this.lblDesignation.Text = "Désignation";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(320, 277);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(220, 20);
            this.txtDesignation.TabIndex = 2;
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(12, 312);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(54, 13);
            this.lblCategorie.Text = "Catégorie";
            // 
            // txtCategorie
            // 
            this.txtCategorie.Location = new System.Drawing.Point(90, 309);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(140, 20);
            this.txtCategorie.TabIndex = 3;
            // 
            // lblQuantite
            // 
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(250, 312);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(47, 13);
            this.lblQuantite.Text = "Quantité";
            // 
            // numQuantite
            // 
            this.numQuantite.Location = new System.Drawing.Point(320, 310);
            this.numQuantite.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(80, 20);
            this.numQuantite.TabIndex = 4;
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Location = new System.Drawing.Point(420, 312);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(55, 13);
            this.lblPrix.Text = "Prix / jour";
            // 
            // numPrix
            // 
            this.numPrix.DecimalPlaces = 2;
            this.numPrix.Location = new System.Drawing.Point(485, 310);
            this.numPrix.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numPrix.Name = "numPrix";
            this.numPrix.Size = new System.Drawing.Size(80, 20);
            this.numPrix.TabIndex = 5;
            // 
            // lblEtat
            // 
            this.lblEtat.AutoSize = true;
            this.lblEtat.Location = new System.Drawing.Point(12, 344);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(27, 13);
            this.lblEtat.Text = "État";
            // 
            // cboEtat
            // 
            this.cboEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtat.FormattingEnabled = true;
            this.cboEtat.Location = new System.Drawing.Point(90, 341);
            this.cboEtat.Name = "cboEtat";
            this.cboEtat.Size = new System.Drawing.Size(140, 21);
            this.cboEtat.TabIndex = 6;
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(560, 275);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(100, 28);
            this.btnNouveau.TabIndex = 7;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(670, 275);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(100, 28);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(560, 309);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(100, 28);
            this.btnSupprimer.TabIndex = 9;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnActualiser
            // 
            this.btnActualiser.Location = new System.Drawing.Point(670, 309);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(100, 28);
            this.btnActualiser.TabIndex = 10;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // FormMateriel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 381);
            this.Controls.Add(this.btnActualiser);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.cboEtat);
            this.Controls.Add(this.lblEtat);
            this.Controls.Add(this.numPrix);
            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.numQuantite);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.txtCategorie);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.gridMateriel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMateriel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion du matériel";
            this.Load += new System.EventHandler(this.FormMateriel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMateriel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView gridMateriel;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.TextBox txtCategorie;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.NumericUpDown numPrix;
        private System.Windows.Forms.ComboBox cboEtat;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.Label lblEtat;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnActualiser;
    }
}
