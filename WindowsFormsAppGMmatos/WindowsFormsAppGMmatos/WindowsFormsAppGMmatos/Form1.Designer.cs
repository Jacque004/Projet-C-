namespace WindowsFormsAppGMmatos
{
    partial class FormGenerale
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

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.Clients = new System.Windows.Forms.Button();
            this.Materiel = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(150, 50);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(300, 32);
            this.lblTitre.TabIndex = 2;
            this.lblTitre.Text = "Gestion Matériel";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clients
            // 
            this.Clients.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Clients.Location = new System.Drawing.Point(110, 140);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(180, 55);
            this.Clients.TabIndex = 0;
            this.Clients.Text = "Clients";
            this.Clients.UseVisualStyleBackColor = true;
            this.Clients.Click += new System.EventHandler(this.Clients_Click);
            // 
            // Materiel
            // 
            this.Materiel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Materiel.Location = new System.Drawing.Point(310, 140);
            this.Materiel.Name = "Materiel";
            this.Materiel.Size = new System.Drawing.Size(180, 55);
            this.Materiel.TabIndex = 1;
            this.Materiel.Text = "Matériel";
            this.Materiel.UseVisualStyleBackColor = true;
            this.Materiel.Click += new System.EventHandler(this.Materiel_Click);
            // 
            // FormGenerale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.Materiel);
            this.Controls.Add(this.Clients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGenerale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Matos 13";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button Clients;
        private System.Windows.Forms.Button Materiel;
        private System.Windows.Forms.Label lblTitre;
    }
}
