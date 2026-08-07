using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsAppGMmatos
{
    public partial class FormGenerale : Form
    {
        public FormGenerale()
        {
            InitializeComponent();
            ChargerLogo();
        }

        private void ChargerLogo()
        {
            var chemin = Path.Combine(Application.StartupPath, "Resources", "gmatos.png");
            if (!File.Exists(chemin))
            {
                chemin = Path.Combine(Application.StartupPath, "gmatos.png");
            }

            if (File.Exists(chemin))
            {
                picLogo.Image = Image.FromFile(chemin);
            }
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            using (var dlg = new Formclient())
            {
                dlg.ShowDialog(this);
            }
        }

        private void Materiel_Click(object sender, EventArgs e)
        {
            using (var dlg = new FormMateriel())
            {
                dlg.ShowDialog(this);
            }
        }
    }
}
