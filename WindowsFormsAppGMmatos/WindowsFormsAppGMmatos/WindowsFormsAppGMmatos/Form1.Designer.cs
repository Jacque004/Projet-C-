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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.Clients = new System.Windows.Forms.Button();
            this.Materiel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(200, 25);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // Clients
            // 
            this.Clients.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Clients.Location = new System.Drawing.Point(110, 250);
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
            this.Materiel.Location = new System.Drawing.Point(310, 250);
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
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.Materiel);
            this.Controls.Add(this.Clients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGenerale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Matos 13";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button Clients;
        private System.Windows.Forms.Button Materiel;
    }
}
