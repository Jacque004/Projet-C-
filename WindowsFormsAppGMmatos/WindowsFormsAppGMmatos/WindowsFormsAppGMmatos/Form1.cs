using System;
using System.Windows.Forms;

namespace WindowsFormsAppGMmatos
{
    public partial class FormGenerale : Form
    {
        public FormGenerale()
        {
            InitializeComponent();
        }

        private void FormGenerale_Load(object sender, EventArgs e)
        {
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
