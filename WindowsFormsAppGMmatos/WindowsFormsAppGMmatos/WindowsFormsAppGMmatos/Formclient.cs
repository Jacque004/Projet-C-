using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppGMmatos.Data;
using WindowsFormsAppGMmatos.Models;

namespace WindowsFormsAppGMmatos
{
    public partial class Formclient : Form
    {
        private int? _selectedId;

        public Formclient()
        {
            InitializeComponent();
        }

        private async void Formclient_Load(object sender, EventArgs e)
        {
            await ChargerAsync();
        }

        private async Task ChargerAsync()
        {
            try
            {
                var clients = await ApiService.GetClientsAsync();
                gridClients.DataSource = clients;
                ConfigurerColonnes();
                ViderFormulaire();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger les clients.\n\n" + ex.Message +
                    "\n\nVérifiez qu'Apache/MySQL sont démarrés et que l'API est accessible.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurerColonnes()
        {
            if (gridClients.Columns.Count == 0) return;
            gridClients.Columns["Id"].HeaderText = "ID";
            gridClients.Columns["Id"].Width = 50;
            gridClients.Columns["Nom"].HeaderText = "Nom";
            gridClients.Columns["Prenom"].HeaderText = "Prénom";
            gridClients.Columns["Email"].HeaderText = "Email";
            gridClients.Columns["Telephone"].HeaderText = "Téléphone";
            gridClients.Columns["Adresse"].HeaderText = "Adresse";
            gridClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridClients.MultiSelect = false;
            gridClients.ReadOnly = true;
            gridClients.AllowUserToAddRows = false;
        }

        private void gridClients_SelectionChanged(object sender, EventArgs e)
        {
            if (gridClients.CurrentRow == null || gridClients.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            var client = gridClients.CurrentRow.DataBoundItem as Client;
            if (client == null) return;

            _selectedId = client.Id;
            txtNom.Text = client.Nom;
            txtPrenom.Text = client.Prenom;
            txtEmail.Text = client.Email ?? string.Empty;
            txtTelephone.Text = client.Telephone ?? string.Empty;
            txtAdresse.Text = client.Adresse ?? string.Empty;
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderFormulaire();
        }

        private async void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Nom et prénom sont obligatoires.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = new Client
            {
                Id = _selectedId ?? 0,
                Nom = txtNom.Text.Trim(),
                Prenom = txtPrenom.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telephone = txtTelephone.Text.Trim(),
                Adresse = txtAdresse.Text.Trim()
            };

            try
            {
                if (_selectedId.HasValue)
                {
                    await ApiService.UpdateClientAsync(client);
                }
                else
                {
                    await ApiService.CreateClientAsync(client);
                }

                await ChargerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Sélectionnez un client à supprimer.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Supprimer ce client ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await ApiService.DeleteClientAsync(_selectedId.Value);
                await ChargerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualiser_Click(object sender, EventArgs e)
        {
            await ChargerAsync();
        }

        private void ViderFormulaire()
        {
            _selectedId = null;
            txtNom.Clear();
            txtPrenom.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            gridClients.ClearSelection();
            txtNom.Focus();
        }
    }
}
